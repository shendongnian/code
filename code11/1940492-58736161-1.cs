    public static string GetSubstringToChar(string input, char delimeter = '[')
    {
        if (input == null || !input.Contains(delimeter)) return input;
        return input.Substring(0, input.IndexOf(delimeter));
    }
