    private IEnumerable<KeyValuePair<string, string>> GetLeaves(XElement element)
    {
        if (!element.HasElements)
            yield return new KeyValuePair<string, string>(GetPath(element), element.Value);
        else
            foreach (var leave in element.Elements().SelectMany(GetLeaves))
                yield return leave;
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
