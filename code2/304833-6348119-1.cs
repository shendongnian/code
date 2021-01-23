    StringBuilder sb = new StringBuilder();
    string word = "mamá";
    foreach (char c in word)
    {
        if (' ' <= c && c <= '~')
        {
            sb.Append(c);
        }
        else
        {
            sb.AppendFormat("\\U{0:X4}", (int)c);
        }
    }
    string escapedWord = sb.ToString();
