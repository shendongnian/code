    void Main()
    {
        string html = "<html><span>we do like <b>bold</b> stuff</span></html>";
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        RemoveTags(doc, "span");
        Console.WriteLine(doc.DocumentNode.OuterHtml);
    }
    
    public static void RemoveTags(HtmlDocument html, string tagName)
    {
        var tags = html.DocumentNode.SelectNodes("//" + tagName);
        if (tags!=null)
        {
            foreach (var tag in tags)
            {
                if (!tag.HasChildNodes)
                {
                    tag.ParentNode.RemoveChild(tag);
                    continue;
                }
    
                for (var i = tag.ChildNodes.Count - 1; i >= 0; i--)
                {
                    var child = tag.ChildNodes[i];
                    tag.ParentNode.InsertAfter(child, tag);
                }
                tag.ParentNode.RemoveChild(tag);
            }
        }
    }
