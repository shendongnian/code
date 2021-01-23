    public static string GetWebPageHtmlFromUrl(string url)
    {
        var hw = new HtmlWeb();
        HtmlDocument doc = hw.Load(url);
        return doc.DocumentNode.OuterHtml;
    }
