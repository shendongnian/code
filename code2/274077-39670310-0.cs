    public static int RegexIndexOf(this string str, string pattern)
    {
        var m = Regex.Match(str, pattern);
        return m.Success ? m.Index : -1;
    }
