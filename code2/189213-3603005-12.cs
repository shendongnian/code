    public static string RemoveRepeatedSpaces(string s)
    {
        StringBuilder sb = new StringBuilder(s.Length);
        char lastChar = '\0';
        foreach (char c in s)
            if (c != ' ' || lastChar != ' ')
                sb.Append(lastChar = c);
        return sb.ToString();
    }
