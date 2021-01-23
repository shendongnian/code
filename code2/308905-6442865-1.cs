    var images = doc.DocumentNode.SelectNodes("//img");
    if (images != null)
    {
        foreach (HtmlNode image in images)
        {
            var alt = image.GetAttributeValue("alt", "");
            var nodeForReplace = HtmlTextNode.CreateNode(alt);
            image.ParentNode.ReplaceChild(nodeForReplace, image);
        }
    }
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
    {
        doc.Save(writer);
    }
