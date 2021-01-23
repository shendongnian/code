    private static string RemoveWhiteSpace(string value)
    {
        if (value == null) { return null; }
        var sb = new StringBuilder();
        var lastCharWs = false;
        foreach (var c in value)
        {
            if (char.IsWhiteSpace(c))
            {
                if (lastCharWs) { continue; }
                sb.Append(' ');
                lastCharWs = true;
            }
            else
            {
                sb.Append(c);
                lastCharWs = false;
            }
        }
        return sb.ToString();
    }
