    public static bool Equals_Linq(string s1, string s2)
    {
        return Enumerable.SequenceEqual(
            s1.Where(c => !char.IsWhiteSpace(c)).Select(char.ToUpperInvariant),
            s2.Where(c => !char.IsWhiteSpace(c)).Select(char.ToUpperInvariant));
    }
    public static bool Equals_Regex(string s1, string s2)
    {
        return string.Equals(
            Regex.Replace(s1, @"\s", ""),
            Regex.Replace(s2, @"\s", ""),
            StringComparison.OrdinalIgnoreCase);
    }
