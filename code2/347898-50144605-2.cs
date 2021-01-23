    /// <summary>
    /// Ensure that the string is either the empty string `""` or contains
    /// *ONLY SPACES* without any other character OR whitespace type.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>`true` if string is empty or only made up of spaces. Otherwise `false`.</returns>
    public static bool IsEmptyOrAllSpaces(this string str)
    {
        return null != str && str.All(c => c.Equals(' '));
    }
