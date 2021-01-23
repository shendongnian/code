    public static string StripHTML(this string HTMLText)
    {
        var reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
        return reg.Replace(HTMLText, "").Replace("&nbsp;", " ");
    }
