    public static string CleanUpRteOutput(this string s)
            {
                if (s != null)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(s);
                    RemoveTag(doc, "script");
                    RemoveTag(doc, "link");
                    RemoveTag(doc, "style");
                    RemoveTag(doc, "meta");
                    RemoveTag(doc, "comment");
    ...
