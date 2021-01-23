    public static string Clear(this string input)
    {
        return input
            .ClearSpecialChars()
            .ClearDoubleSpaces()
            .Trim();
    }
