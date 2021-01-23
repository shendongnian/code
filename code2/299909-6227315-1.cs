        private void Form_Load(object sender, EventArgs e)
        {
            // append the function to the RichTextBox's TextChanged event
            MyRichTextBox.TextChanged += Capitalize_Bold_FirstLine;
        }
        private void Capitalize_Bold_FirstLine(object sender, EventArgs e)
        {
            RichTextBox box = sender as RichTextBox;
            if (box != null && box.Text != "")
            {
                // get the current selection text of the textbox
                int ss = box.SelectionStart;
                int sl = box.SelectionLength;
                // get the position where the first line ends
                int firstLineEnd = box.Text.IndexOf('\n');
                if (firstLineEnd < 0)
                    firstLineEnd = box.Text.Length;
                // split the lines
                string[] lines = box.Text.Split('\n');
                // capitalize the first line
                lines[0] = lines[0].ToUpper();
                // join them back and set the new text
                box.Text = String.Join("\n", lines);
                // select the first line and make it bold
                box.SelectionStart = 0;
                box.SelectionLength = firstLineEnd;
                box.SelectionFont = new Font(box.Font, FontStyle.Bold);
                // select the rest and make it regular
                box.SelectionStart = firstLineEnd;
                box.SelectionLength = box.Text.Length - firstLineEnd;
                box.SelectionFont = new Font(box.Font, FontStyle.Regular);
                // go back to what the user had selected
                box.SelectionStart = ss;
                box.SelectionLength = sl;
            }
        }
