    public static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).
                           Replace(@"\*", ".*").
                           Replace(@"\?", ".") + "$";
    }
