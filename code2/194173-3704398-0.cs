    public static string CustomReplace(this string s)
    {
        var sb = new StringBuilder(s);
        for (int i = Math.Max(0, s.IndexOf('@')); i < sb.Length; i++)
            if (sb[i] == '@' || sb[i] == '.')
                sb[i] = '_';
        return sb.ToString();
    }
