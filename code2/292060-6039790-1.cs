    public static class Parser
    {
        public static string ParseSomethingCool(string text, string someRegex)
        {
            return Regex.Match(text, someRegex).Value;
        }
    }
