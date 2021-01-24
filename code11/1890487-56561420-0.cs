string ExpandTabs(string input, int tabWidth = 8)
{
    if (string.IsNullOrEmpty(input))
        return input;
    var result = new System.Text.StringBuilder(input.Length);
    foreach (var ch in input)
    {
        if (ch == '\t')
        {
            result.Append(' ');
            while (result.Length % tabWidth != 0)
                result.Append(' ');
        }
        else
            result.Append(ch);
    }
    return result.ToString();
}
Note that this is a fairly naive function. It won't work properly if there are embedded `\r` or `\n` characters, and other characters could also cause problems.
