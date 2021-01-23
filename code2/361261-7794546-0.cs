    public static string JsEncode(string text)
    {
        StringBuilder safe = new StringBuilder();
        foreach (char ch in text)
        {
            // Hex encode "\xFF"
            if (ch <= 127)
                safe.Append("\\x" + ((int)ch).ToString("x2"));
            // Unicode hex encode "\uFFFF"
            else
                safe.Append("\\u" + ((int)ch).ToString("x4"));
        }
        return safe.ToString();
    }
