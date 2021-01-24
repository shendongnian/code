    public TagBuilder GetTagBuilder(string html)
    {
        var node = HtmlAgilityPack.HtmlNode.CreateNode(html);
        var tagBuilder = new TagBuilder(node.Name);
        tagBuilder.MergeAttributes(node.Attributes.ToDictionary(x => x.Name, x => x.Value));
        tagBuilder.InnerHtml = node.InnerHtml;
        return tagBuilder;
    }
