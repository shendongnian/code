    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
         // whitespace definition
         char[] whitespace = new char[] { ' ', '\r', '\n', '\t' };
         int charPosition = this.richTextBox1.GetCharIndexFromPosition(e.Location);
         string fullText = this.richTextBox1.Text;
         // if we are on whitespace, exit
         if (whitespace.Contains(fullText[charPosition]))
         {
             return;
         }
         // find a whitespace towards the start of the text
         int firstWhiteSpace = charPosition;
         while (firstWhiteSpace > 0
             && firstWhiteSpace < fullText.Length
             && !whitespace.Contains(fullText[firstWhiteSpace]))
         {
             firstWhiteSpace--;
         }
         if (firstWhiteSpace!=0)
             firstWhiteSpace++;
         // find the next whitespace
         int lastWhiteSpace = fullText.IndexOfAny(whitespace, charPosition);
         if (lastWhiteSpace == -1)
             lastWhiteSpace = fullText.Length;
            
         // substring the word out of the flat text
         string word = fullText.Substring(
             firstWhiteSpace, 
             lastWhiteSpace - firstWhiteSpace);
         // show the result
         label1.Text = String.Format("pos:{0} fsp:{1}, lsp:{2}, len:{3}, word:{4}", 
             charPosition, 
             firstWhiteSpace, 
             lastWhiteSpace, 
             fullText.Length, word);
             
     }
