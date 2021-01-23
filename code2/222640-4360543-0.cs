    public static string GetComments(string html)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        string s = "";
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//ol"))
        {
            s += node.OuterHtml;
        }
    
        return s;
    }
