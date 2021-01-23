    private void SetCaretPosition(int rows, int col)
    {
        int curPos = 0;
        if (richTextBox1.Lines.Length >= rows)
        {    
            for (int i = 0; i < rows - 1; ++i)
            {
               curPos += richTextBox1.Lines[i].Length + 1; //add 1 for the newline character
            }
            richTextBox1.SelectionStart = curPos + col; 
        }
        else
            richTextBox1.SelectionStart = richTextBox1.TextLength;
        richTextBox1.ScrollToCaret();             
    }
