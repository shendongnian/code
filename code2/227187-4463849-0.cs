    private static readonly Regex hrefRegex =
        new Regex("(?<=href=\")http://[^\"]*(?=\")", RegexOptions.IgnoreCase);
    public static string InsertTrackingCode(string html)
    {
        return hrefRegex.Replace(html,
            match => "%%track " + match.Groups[0].Value + "%%");
    }
