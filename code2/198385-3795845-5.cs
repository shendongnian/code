    /// <summary>
    /// Concatenates the specified number of repetitions of the current string.
    /// </summary>
    /// <param name="input">The string to be repeated.</param>
    /// <param name="numTimes">The number of times to repeat the string.</param>
    /// <returns>A concatenated string containing the original string the specified number of times.</returns>
    public static string Repeat(this string input, int numTimes)
    {
        if (numTimes == 0) return "";
        if (numTimes == 1) return input;
        if (numTimes == 2) return input + input;
        var sb = new StringBuilder();
        for (int i = 0; i < numTimes; i++)
            sb.Append(input);
        return sb.ToString();
    }
