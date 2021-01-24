    public static string Format(this string s, string separator, int length)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i += length)
        {
            sb.Append(s.Substring(i, Math.Min(s.Length - i, length)));
            if (i < s.Length - length)
            {
                sb.Append(separator);
            }
        }
        return sb.ToString();
    }
