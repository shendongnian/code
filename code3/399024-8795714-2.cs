    public Dictionary<string, string> GetLeaves(XDocument doc)
    {
        var dict = doc
            .Descendants()
            .Where(e => !e.HasElements)
            .ToDictionary(e => GetPath(e), e.Value);
        return dict;
    }
    private string GetPath(XElement element)
    {
        var nodes = new List<string>();
        var node = element;
        while (node != null)
        {
            nodes.Add(node.Name.ToString());
            node = node.Parent;
        }
        return string.Join("/", Enumerable.Reverse(nodes));
    }
