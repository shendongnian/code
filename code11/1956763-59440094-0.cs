    public bool match(string original, string pattern)
    {
        if (string.IsNullOrEmpty(original)) return false;
        if (string.IsNullOrEmpty(pattern)) return false;
        if (pattern.Length > original.Length) return false;
        pattern = "^" + pattern.Replace("3", @"\d");
        return System.Text.RegularExpressions.Regex.IsMatch(original, pattern);
    }
