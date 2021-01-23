    public static string EscapeString(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
                    int i = (int)c;
                    if (i < 32 || i > 126)
                    {
                        sb.AppendFormat("&#{0};", i);
                    }
                    else
                    {
                        sb.Append(c);
                    }
        }
        return sb.ToString();
    }
