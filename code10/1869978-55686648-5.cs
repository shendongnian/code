    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox1.Checked)
                {
                    foreach(Control ctrl in groupBox1.Controls)
            {
                if (ctrl is RichTextBox)
                {
                    RichTextBox box = ctrl as RichTextBox;
                    box.SelectionFont = new Font(box.SelectionFont, box.SelectionFont.Style | FontStyle.Bold);
                }
            }
                }
                else
                {
                    foreach(Control ctrl in groupBox1.Controls)
            {
                if (ctrl is RichTextBox)
                {
                    RichTextBox box = ctrl as RichTextBox;
                    box.SelectionFont = new Font(box.SelectionFont, box.SelectionFont.Style | FontStyle.Regular);
                }
            }
                }
                if (checkBox2.Checked)
                {
                    foreach(Control ctrl in groupBox1.Controls)
            {
                if (ctrl is RichTextBox)
                {
                    RichTextBox box = ctrl as RichTextBox;
                    box.SelectionFont = new Font(box.SelectionFont, box.SelectionFont.Style | FontStyle.Italic);
                }
            }
                
            }
