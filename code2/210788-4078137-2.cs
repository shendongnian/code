           private void AddText(string text)
        {
            string[] str = text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            
            if (str.Length == 2)
            {
                richTextBox1.DeselectAll();
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.AppendText(Environment.NewLine + str[0] + ";");
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                richTextBox1.AppendText(str[1]);
            } // Else?? Well, do something else..
        }
