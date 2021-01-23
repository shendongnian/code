    public static string Encode(string source)
    {
        if (string.IsNullOrEmpty(source)) return string.Empty;
        var sb = new StringBuilder(source.Length);
        foreach (char c in source)
        {
            if (c >= 'a' && c <= 'z')
            {
                sb.Append(c);
            }
            else if (c >= 'A' && c <= 'Z')
            {
                sb.Append(c);
            }
            else if (c >= '0' && c <= '9')
            {
                sb.Append(c);
            }
            else
            {
                sb.AppendFormat("&#{0};",Convert.ToInt32(c));
            }
        }
        return sb.ToString();
    }
