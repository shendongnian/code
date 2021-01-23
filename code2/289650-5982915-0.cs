    // Update lines to have extra length past length of window
    string[] linez = new string[richTextBox1.Lines.Length];
    for (int i = 0; i < richTextBox1.Lines.Length; i++)
    {
       linez[i] = richTextBox1.Lines[i] + new string(' ', 1000);
    }
    richTextBox1.Clear();
    richTextBox1.Lines = linez;
    for(int i = 0; i < richTextBox1.Lines.Length; i++)
    {
       int first = richTextBox1.GetFirstCharIndexFromLine(i);
       richTextBox1.Select(first, richTextBox1.Lines[i].Length);
       richTextBox1.SelectionBackColor = (i % 2 == 0) ? Color.Red : Color.White;
       richTextBox1.SelectionColor = (i % 2 == 0) ? Color.Black : Color.Green;
    }
    richTextBox1.Select(0,0);
