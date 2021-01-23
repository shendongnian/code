    public static string DeleteLines(string input, int linesToSkip)
    {
        int startIndex = 0;
        for (int i = 0; i < linesToSkip; ++i)
            startIndex = input.IndexOf('\n', startIndex) + 1;
        return input.Substring(startIndex);
    }
