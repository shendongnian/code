    static string ReplaceBreaks(string value)
    {
        return Regex.Replace(value, @"(<br */>)|(\[br */\])", "\n");
    }
    static string ProcessCodeBlocks(string value)
    {
        StringBuilder result = new StringBuilder();
        Match m = Regex.Match(value, @"\[pre=(?<lang>[a-z]+)\](?<code>.*?)\[/pre\]");
        int index = 0;
        while( m.Success )
        {
            if( m.Index > index )
                result.Append(value, index, m.Index - index);
            result.AppendFormat("<pre class=\"{0}\">", m.Groups["lang"].Value);
            result.Append(ReplaceBreaks(m.Groups["code"].Value));
            result.Append("</pre>");
            index = m.Index + m.Length;
            m = m.NextMatch();
        }
        if( index < value.Length )
            result.Append(value, index, value.Length - index);
        return result.ToString();
    }
