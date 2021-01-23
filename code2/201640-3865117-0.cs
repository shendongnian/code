    public static string EscapeString(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
                    int i = (int)c;
                    if (i < 32 || i > 127)
                    {
                        sb.AppendFormat("\\u{0:X04}", i);
                    }
                    else
                    {
                        sb.Append(c);
                    }
        }
        return sb.ToString();
    }
