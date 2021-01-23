    String text = richTextBox1.Text.Trim();
    int count = 0, index = 0;
    while (index < text.Length)
    {
       // check if current char is part of a word
       while (index < text.Length && Char.IsWhitespace(text[index]) == false)
           index++;
       count++;
       // skip whitespace until next word
       while (index < text.Length && Char.IsWhitespace(text[index]) == true)
           index++;
    }
