    HtmlNode firstLiNode = pos.Nodes.FirstOrDefault(n => n.Name.Equals("li"));
    if (firstLiNode != null)
    {
        // Retrieve all LI nodes that should be wrapped with the UL tag.
        IEnumerable<HtmlNode> liNodes = doc.DocumentNode.SelectNodes(@"//li");
        HtmlNode ulNode = HtmlNode.CreateNode("<ul>");
    
        // Insert LI tags into newly created UL tag.
        foreach (HtmlNode liNode in liNodes)
        {
            HtmlNode clone = liNode.CloneNode(true);
            ulNode.AppendChild(clone);
        }
    
        // Insert newly created UL tag with child LI nodes before "original" LI tag without UL tag.
        doc.DocumentNode.InsertBefore(ulNode, firstLiNode);
    
        // Remove LI tags that are not wrapped with UL tag.
        foreach (HtmlNode liNode in liNodes)
        {
            doc.DocumentNode.RemoveChild(liNode);
        }
    }
