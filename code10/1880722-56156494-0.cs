    public static Node GetHighestRelevantAncestorOrSelf(Node node)
    {
        Node result = node;
        while (true)
        {
            Node parent = GetParent(result);
            if (parent == null || IsBarrierNode(parent)) return result; // This exits the loop
            result = parent;
        }
    }
