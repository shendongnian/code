    public Node GetSubtree(int value, int depth)
    {
        int foundDepth;
        return GetSubtreeHelper(value, depth, out foundDepth);
    }
    private Node GetSubtreeHelper(int value, int depth, out int foundDepth)
    {
        if (Value == value)
        {
            foundDepth = 0;
            return depth == foundDepth ? this : null;
        }
        if (Left != null)
        {
            var node = Left.GetSubtreeHelper(value, depth, out foundDepth);
            if (foundDepth != -1)
            {
                return ++foundDepth == depth ? this : node;
            }
        }
        if (Right != null)
        {
            var node = Right.GetSubtreeHelper(value, depth, out foundDepth);
            if (foundDepth != -1)
            {
                return ++foundDepth == depth ? this : node;
            }
        }
        foundDepth = -1;
        return null;
    }
