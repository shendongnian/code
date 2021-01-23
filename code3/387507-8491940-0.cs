    private bool Validate(ITreeCollection items) where T : TreeNodeBase
    {
        foreach (TreeNodeBase node in (IEnumerable) items)
        {
            if (node.Items != null)
            {
                if (!Validate(((TreeNodeBase) itm).Items)
                {
                    return false;
                }
            }
            if (!Validate(node))
            {
                return false;
            }
        }
        return true;
    }
    private bool Validate(TreeNodeBase node)
    {
        if (node is BananaNode)
        {
            var bananaNode = (BananaNode) node;
            //TODO do BananaNode specific validation
        }
        else if (node is AppleNode)
        {
            var appleNode = (AppleNode) node;
            //TODO do AppleNode specific validation
        }
        else
        {
            throw new ArgumentOutOfRangeException("Cannot validate node of type '" + node.GetType().Name + "'.");
        }
    }
