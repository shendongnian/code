    private static string RemoveXmlInvalidCharacters(string s)
    {
        return Regex.Replace(
            s,
            @"[^\u0009\u000A\u000D\u0020-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]",
            string.Empty);
    }
