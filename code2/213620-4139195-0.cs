    public IEnumerable<HtmlNode> Traverse(IEnumerable<HtmlNode> nodes)
    {
        foreach (var node in nodes)
        {
            yield return node;
            foreach (var child in Traverse(ChildNodes(node)))
                yield return child;
        }
    }
    
    private IEnumerable<HtmlNode> ChildNodes(HtmlNode node)
    {
        return node.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Element);
    }
    
    
    public SharpQuery(IEnumerable<HtmlNode> nodes, SharpQuery previous = null)
    {
        if (nodes == null) throw new ArgumentNullException("nodes");
        _previous = previous; // Is this necessary?
        _context = new List<HtmlNode>(nodes);
    }
