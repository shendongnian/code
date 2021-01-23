    public static string ClearSpecialChars(this string input)
    {
        foreach (var ch in new[] { "\r", "\n", "<br>", etc })
        {
            input = input.Replace(ch, String.Empty);
        }
        return input;
    }
