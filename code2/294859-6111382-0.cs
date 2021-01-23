    public static string[] SplitWhitespace (string input)
    {
        char[] whitespace = new char[] { ' ', '\t' };
        return input.Split(whitespace);
    }
