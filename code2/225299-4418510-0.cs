    public static string RemoveSpecialCharacters(string input)
    {
        Regex r = new Regex("(?:[\\W]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return r.Replace(input, String.Empty);
    }
