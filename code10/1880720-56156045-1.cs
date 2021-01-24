    public Node GetTopNode(Node node)
    {
        var parent = GetParent(node);
        return (parent != null && !IsBarrierNode(parent))
            ? GetTopNode(parent)
            : parent;
    }
