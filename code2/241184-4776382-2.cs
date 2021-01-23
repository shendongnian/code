    static string GetFirstLine(string text)
    {
        int? newlinePos = GetIndex(text, "\r") ?? GetIndex(text, "\n");
        if (newlinePos.HasValue)
        {
            return text.Substring(0, newlinePos.Value);
        }
        return text;
    }
    // Not really necessary -- just a convenience method.
    static int? GetIndex(string text, string substr)
    {
        int index = text.IndexOf(substr);
        return index >= 0 ? (int?)index : null;
    }
