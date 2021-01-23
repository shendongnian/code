    private void ColorTheKs()
    {
        for(int i = 0; i< richTextBox1.Text.Length; i++)
        {
            if (richTextBox1.Text[i] == 'K')
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionBackColor = Color.Yellow;
            }
        }
    }
