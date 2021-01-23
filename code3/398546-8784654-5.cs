    var text = richTextBox1.Text.Trim();
    int wordCount = 0, index = 0;
    while (index < text.Length)
    {
       // check if current char is part of a word
       while (index < text.Length && !char.IsWhiteSpace(text[index]))
           index++;
       if (index < text.Length)
           wordCount++;
       // skip whitespace until next word
       while (index < text.Length && char.IsWhiteSpace(text[index]))
           index++;
    }
