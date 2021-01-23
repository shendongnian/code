    private static readonly Regex scriptTagRegex = new Regex(
        "script", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    /// <summary>
    ///     Processes the provided string, creating a quoted JavaScript string literal.
    /// </summary>
    /// <param name="str">The string to process</param>
    /// <returns>A string containing a quoted JavaScript string literal</returns>
    public static string JavaScriptStringLiteral(string str)
    {
        var sb = new StringBuilder();
        sb.Append("\"");
        foreach (char c in str)
        {
            switch (c)
            {
                case '\"':
                    sb.Append("\\\"");
                    break;
                case '\\':
                    sb.Append("\\\\");
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                default:
                    int i = (int)c;
                    if (i < 32 || i > 127)
                    {
                        sb.AppendFormat("\\u{0:X04}", i);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        sb.Append("\"");
        // If a Javascript tag contains "</script>", then it terminates a
        // script block.  Start by replacing each 's'/'S' with an escape
        // sequence so it doesn't trigger this.
        return scriptTagRegex.Replace(
            sb.ToString(),
            m => (m.Value[0] == 's' ? "\\u0073" : "\\u0053") + m.Value.Substring(1));
    }
