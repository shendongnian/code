        public static void ChangeTextcolor(string textToMark, Color color, RichTextBox richTextBox)
        {
            int startIndex = 0;
            string text = richTextBox.Text;
            startIndex = text.IndexOf(textToMark);
            System.Drawing.Font newFont = new Font("Verdana", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, false);
            
            try
            {
                foreach (string line in richTextBox.Lines)
                {
                    if (line.Contains(textToMark))
                    {
                        richTextBox.Select(startIndex, textToMark.Length);
                        richTextBox.SelectionColor = color;
                        richTextBox.SelectionFont = newFont;
                    }
                }
            }
            catch{ }
        }
