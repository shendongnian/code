    public AccessibleTreeItem GetParent(AccessibleTreeItem node, int depth)
    {
        if(depth <= 1) // can't go higher than 1
        {
            return node.Parent;
        }
        else
        {
            return GetParent(node.Parent, depth-1);
        }
    }
