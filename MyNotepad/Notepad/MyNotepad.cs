using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class MyNotepad : Form
    {
        public static string FindText;
        public static string ReplaceText;
        string path = "";
        public static Boolean matchcase;
        int d;
        
        public MyNotepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                if (path == "")
                {
                    var d = MessageBox.Show("Save new workspace?", "Notepad", MessageBoxButtons.YesNoCancel);

                        if (d == System.Windows.Forms.DialogResult.Yes)
                        {
                            saveToolStripMenuItem_Click(sender, e);
                         }
                        else if (d == System.Windows.Forms.DialogResult.No)
                        {
                            richTextBox1.Clear();
                        }
                }
                    else
                    {
                        richTextBox1.Clear();
                    }
                }
            }
        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control

        }
        private RichTextBox GetRichTextBox()
        {
        RichTextBox rtb = null; //making it initially null
        TabPage tp = tabControl1.SelectedTab; // saves the tab selection status in a tabpage type variable
        if (tp != null)
        {
           rtb = tp.Controls[0] as RichTextBox; //sets the selected rich text box index as primary
         }
         return rtb;
         }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.FileName = "";
            var d = openFileDialog1.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
                path = openFileDialog1.FileName;
                this.Text = path;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                richTextBox1.SaveFile(path);
            }
            else
            {
                saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                var r = saveFileDialog1.ShowDialog();
                if (r == System.Windows.Forms.DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                    path = saveFileDialog1.FileName;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            var r = saveFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                path = saveFileDialog1.FileName;
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Find r = new Find();
            r.ShowDialog();

            if (ReplaceText != "")
            {
                d = richTextBox1.Find(ReplaceText);
            }
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReplaceText != "")
                if (matchcase == true)
                {
                    d = richTextBox1.Find(ReplaceText, (d + 1), richTextBox1.Text.Length, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    d = richTextBox1.Find(ReplaceText, (d + 1), richTextBox1.Text.Length, RichTextBoxFinds.None);
                }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace r = new Replace();
            r.ShowDialog();
            richTextBox1.Find(FindText);
            richTextBox1.SelectedText = ReplaceText;

        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + Convert.ToString(DateTime.Now);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.WordWrap == true)
            {
                richTextBox1.WordWrap = false;
            }
            else
            {
                richTextBox1.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog op = new FontDialog();
            op.Font = richTextBox1.SelectionFont;
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = op.Font;

        }

        private void textColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;

        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog op = new ColorDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = op.Color;

        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About dss = new About();
            dss.ShowDialog();

            //MessageBox.Show("Version 1.0.0 (Build 12345)\nCreated by Tsitsi Hazel Sithole\nCopyright 2016 Sithole Incorporated. All rights reserved.");

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Image";
            op.Filter = "Image File(*.jpg)|*.jpeg|*.png|*.gif|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                pictureBox2.Load(op.FileName);
            this.Text = op.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
                findNextToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
            }
        }

        private void selectedFontColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;

        }

        private void textHighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.0 (Build 12345)\nCreated by Tsitsi Hazel Sithole\nCopyright 2016 Sithole Incorporated. All rights reserved.");
        }

        private void MyNotepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (path == "")
                {
                    var d = MessageBox.Show("Save work?", "Notepad", MessageBoxButtons.YesNoCancel);

                        if (d == System.Windows.Forms.DialogResult.Yes)
                        {
                            saveToolStripMenuItem_Click(sender, e);
                         }
                        
                
                    
                }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(this, e);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem1_Click(this, e);
        }

        private void displayMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                MessageBox.Show(richTextBox1.SelectedText);
            }
        }
     }
}
