    private static int GetChildNodeCount(SiteMapNode node)
    {
        var nodeCount = node.ChildNodes.Count;
        foreach (SiteMapNode subNode in node.ChildNodes)
        {
            nodeCount += GetChildNodeCount(subNode);
        }
        return nodeCount;
    }
