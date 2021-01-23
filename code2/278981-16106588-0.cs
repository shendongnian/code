    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Test
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Example());
            }
        }
    
        public partial class Example : Form
        {
            private System.Windows.Forms.CheckedListBox clb_CheckedListBox;
            private System.Windows.Forms.TextBox txb_TextBox;
    
            public Example()
            {
                this.clb_CheckedListBox = new System.Windows.Forms.CheckedListBox();
                this.txb_TextBox = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                this.clb_CheckedListBox.FormattingEnabled = true;
                this.clb_CheckedListBox.Items.AddRange(new object[] {
                "John 1455", "Jenny 786", "Bob 410", "Adam 97", "Jennifer 4100"});
                this.clb_CheckedListBox.Location = new System.Drawing.Point(13, 13);
                this.clb_CheckedListBox.Name = "clb_CheckedListBox";
                this.clb_CheckedListBox.Size = new System.Drawing.Size(168, 139);
                this.txb_TextBox.Location = new System.Drawing.Point(187, 13);
                this.txb_TextBox.Multiline = true;
                this.txb_TextBox.Name = "txb_TextBox";
                this.txb_TextBox.Size = new System.Drawing.Size(205, 139);
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(404, 166);
                this.Controls.Add(this.txb_TextBox);
                this.Controls.Add(this.clb_CheckedListBox);
                this.ResumeLayout(false);
                this.PerformLayout();
    
                this.txb_TextBox.TextChanged += new System.EventHandler(this.txb_TextBox_TextChanged);
                this.Load += new System.EventHandler(this.TestForm_Load);
            }
    
            private void txb_TextBox_TextChanged(object sender, EventArgs e)
            {
    
                string[] blocks = ((TextBox)sender).Text.Split(' ');
                for (int idx = 0; idx < clb_CheckedListBox.Items.Count; idx++)
                    clb_CheckedListBox.SetItemChecked(idx, clb_CheckedListBox.Items[idx].ToString().Split(' ').Intersect(blocks).Any());
            }
    
            private void TestForm_Load(object sender, EventArgs e)
            {
                this.txb_TextBox.Text = "John 410 Jennys 970 4100";
            }
        }
    }
