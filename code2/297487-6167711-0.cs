        void WriteLog(string txt)
        {
            if(richTextBox1.Lines.Count() == 100)
            {
                DeleteLine(0);
            }
            richTextBox1.AppendText(txt + Environment.NewLine);
            richTextBox1.HideSelection = false;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }
    
        private void DeleteLine(int a_line)
        {
            int start_index = richTextBox1.GetFirstCharIndexFromLine(a_line);
            int count = richTextBox1.Lines[a_line].Length;
    
            // Eat new line chars
            if (a_line < richTextBox1.Lines.Length - 1)
            {
                count += richTextBox1.GetFirstCharIndexFromLine(a_line + 1) -
                    ((start_index + count - 1) + 1);
            }
    
            richTextBox1.Text = richTextBox1.Text.Remove(start_index, count);
        }
