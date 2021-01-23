        private void RemoveLastLineAfter300()
        {
            if(richTextBox1.TextLength != 0)
            {
                int totalCharacters = richTextBox1.Text.Trim().Length;
                int totalLines = richTextBox1.Lines.Length;
                string lastLine = richTextBox1.Lines[totalLines - 1] + "\n";
                string copyOfLastLine = richTextBox1.Lines[totalLines - 1];
                if(totalLines > 300)
                {
                    string newstring = richTextBox1.Text.Substring(0, totalCharacters - lastLine.Length);
                    richTextBox1.Text = newstring;
                }
            }
        }
