    private static readonly Regex cjkCharRegex = new Regex(@"\p{IsCJKUnifiedIdeographs}");
    public static bool IsChinese(this char c)
    {
        return cjkCharRegex.IsMatch(c.ToString());
    }
