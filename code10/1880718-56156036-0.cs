    public Node GetHighestRelevantAncestorOrSelf(Node node)
    {
        Node topNode = null;
        while(node != null && !IsBarrierNode(node))
            node = GetParent(topNode = node);
        return topNode;
    }
