private static SqlString fnHTMLDecodeEncode(SqlString html, bool encode)
    {
        if (html.IsNull)
            return SqlString.Null;
        const RegexOptions REGOPT = RegexOptions.Singleline | RegexOptions.Compiled;
        string s = html.Value;
        var m = Regex.Matches(s, @"(<[!A-Za-z\/][^>]*>", RegexOptions.Singleline | RegexOptions.Compiled);
        int proStart, proLen;
        if (m.Count == 0)
        {
            proStart = 0;
            proLen = s.Length;
        }
        else
        {
            proStart = m[m.Count - 1].Index + m[m.Count - 1].Length;
            proLen = s.Length - proStart;
        }
        for (int i = m.Count; i >= 0; i--)
        {
            if (i < m.Count)
            {
                proStart = (i == 0 ? 0 : m[i - 1].Index + m[i - 1].Length);
                proLen = m[i].Index - proStart;
            }
            if (proLen > 2)
            {
                var orig = s.Substring(proStart, proLen);
                var enc = (encode ? System.Net.WebUtility.HtmlEncode(orig) : System.Net.WebUtility.HtmlDecode(orig));
                if (orig.Length != enc.Length)
                {
                    s = s.Remove(proStart, proLen).Insert(proStart, enc);
                }
                proLen = -1;
            }
        }
        return new SqlString(s);
    }
