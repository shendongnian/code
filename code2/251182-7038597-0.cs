    using umbraco.NodeFactory;
    private static List<Node> FindChildren(Node currentNode, Func<Node, bool> predicate)
    {
        List<Node> result = new List<Node>();
        var nodes = currentNode
            .Children
            .OfType<Node>()
            .Where(predicate);
        if (nodes.Count() != 0)
            result.AddRange(nodes);
        foreach (var child in currentNode.Children.OfType<Node>())
        {
            nodes = FindChildren(child, predicate);
            if (nodes.Count() != 0)
                result.AddRange(nodes);
        }
        return result;
    }
    void Example()
    {
        var nodes = FindChildren(new Node(-1), t => t.NodeTypeAlias.Equals("myDocType"));
        // Do something...
    }
