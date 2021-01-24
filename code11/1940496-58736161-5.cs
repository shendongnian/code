    public static string GetSubstringToChar(string input, char[] delimeters)
    {
        if (input == null || !input.Any(delimeters.Contains)) return input;
        return input.Substring(0, input.IndexOfAny(delimeters));
    }
