    private static string RemoveWhiteSpace(string text)
    {
        return text.Replace(" ", "")
                   .Replace("\r", "")
                   .Replace("\n", "")
                   .Replace("\t", "");
    }
