    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // whitespace definition
            char[] whitespace = new char[] { ' ', '\r', '\n', '\t' };
            int charPosition = this.richTextBox1.GetCharIndexFromPosition(e.Location);
            // if we are on whitespace, exit
            if (whitespace.Contains(this.richTextBox1.Text[charPosition]))
            {
                return;
            }
            // find a whitespace towards the start of the text
            int firstWhiteSpace = charPosition;
            while (firstWhiteSpace > 0 && firstWhiteSpace<this.richTextBox1.Text.Length && !whitespace.Contains(this.richTextBox1.Text[firstWhiteSpace]))
                firstWhiteSpace--;
            if (firstWhiteSpace!=0)
                firstWhiteSpace++;
            // find the next whitespace
            int lastWhiteSpace = this.richTextBox1.Text.IndexOfAny(whitespace, charPosition);
            if (lastWhiteSpace == -1) 
                lastWhiteSpace = this.richTextBox1.Text.Length;
            
            // substring the word out of the flat text
            string word = this.richTextBox1.Text.Substring(firstWhiteSpace, lastWhiteSpace - firstWhiteSpace);
            // show the result
            label1.Text = String.Format("pos:{0} fsp:{1}, lsp:{2}, len:{3}, word:{4}", charPosition, firstWhiteSpace, lastWhiteSpace, this.richTextBox1.Text.Length, word);
               
        }
