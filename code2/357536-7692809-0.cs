    string[] lines = textBox.Lines;
    for (int i = 0; i < lines.Length; i++)
    {
         lines[i] = a + lines[i] + b;
    }
    textBox.Lines = lines;
