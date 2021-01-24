    public static DisclaimerPosition GetPositioning(HtmlNode tag, HtmlNode disclaimer, HtmlNode wordSection)
    {
        if (tag == null) throw new NullReferenceException("Tag is null");
        if (disclaimer == null) throw new NullReferenceException("Tag is null");
        if (wordSection == null) throw new NullReferenceException("Tag is null");
        if (IsDisclaimerInWordSection1(disclaimer)) return DisclaimerPosition.InWordSection;
        if (tag.Name == "img" || tag.Name == "div" || tag.Attributes.FirstOrDefault(attribute => attribute.Name == "class")?.Value == "WordSection1" || !tag.HasChildNodes)
        {
            throw new ArgumentException("Tag is invalid, it's value matches disclaimer or wordSection or it has no children");
        }
        var list = GetNodeWithChildren(tag);
        var disclaimerIndex = list.IndexOf(disclaimer);
        var wordSectionIndex = list.IndexOf(wordSection);
        if (disclaimerIndex == -1) throw new ArgumentException("Disclaimer is -1");
        if (wordSectionIndex == -1) throw new ArgumentException("WordSection is -1");
        list.ForEach(node => Console.WriteLine(node.Name + " " + node.Attributes.Where(attribute => attribute.Name == "class").Select(attribute => attribute.Value).FirstOrDefault()));
        return disclaimerIndex < wordSectionIndex ? DisclaimerPosition.AboveWordSection : DisclaimerPosition.UnderneathWordSection;
    }
    private static List<HtmlNode> GetNodeWithChildren(HtmlNode node)
    {
        var nodes = new List<HtmlNode> { node };
        nodes.AddRange(node
                .ChildNodes
                .Where(child => child.NodeType != HtmlNodeType.Text)
                .SelectMany(GetNodeWithChildren)
                .ToList());
        return nodes;
    }
    public static bool IsDisclaimerInWordSection1(HtmlNode disclaimerTag)
    {
        var tag = disclaimerTag;
        while (tag != null)
        {
            if (tag.Name == "div" &&
                tag.HasAttributes &&
                tag.Attributes.Any(tagAttribute => tagAttribute.Name == "class" && tagAttribute.Value == "WordSection1"))
            {
                return true;
            }
            tag = tag.ParentNode;
        }
        return false;
    }
