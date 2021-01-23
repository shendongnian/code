    public static string TrimEnd(this string input, string suffixToRemove)
    {
        while (input != null && suffixToRemove != null && input.EndsWith(suffixToRemove))
        {
            input = input.Substring(0, input.Length - suffixToRemove.Length);
        }
        return input;
    }
