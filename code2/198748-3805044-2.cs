    public static string ClearDoubleSpaces(this string input)
    {
        while (input.Contains("  ")) // double
        {
            input = input.Replace("  ", " "); // with single
        }
        return input.Trim(); // remove leading and trailing spaces
    }
