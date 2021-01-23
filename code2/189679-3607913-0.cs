private static string FirstWord(string text)
{
    if (text == null) throw new ArgumentNullException("text");
    var builder = new StringBuilder();
            
    for (int index = 0; index &lt; text.Length; index += 1)
    {
        char ch = text[index];
        if (Char.IsWhiteSpace(ch)) break;
        builder.Append(ch);
    }
    return builder.ToString();
}
