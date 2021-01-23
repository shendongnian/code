    public static string ExceptBlanks(this string str)
    {
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if(!char.IsWhiteSpace(c))
                sb.Append(c);
        }
        return sb.ToString();
    }
