    foreach(Control ctrl in groupBox1.Controls)
            {
                if(ctrl is RichTextBox)
                {
                    RichTextBox box = ctrl as RichTextBox;
                    box.SelectionFont = new Font(box.SelectionFont, box.SelectionFont.Style | FontStyle.Bold);
                }
            }
