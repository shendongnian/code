    private static readonly Regex pRegex =
        new Regex("^<p align=\"center\">(.*)</p>$");
    public static string ReplaceString(string input)
    {
        return pRegex.Replace(input,
            match => "<center>" + match.Groups[1].Value + "</center>");
    }
