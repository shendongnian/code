    private bool Validate(ITreeCollection items)
    {
        foreach (TreeNodeBase node in (IEnumerable) items)
        {
            // validate the node itself first
            if (!Validate(node))
            {
                return false;
            }
            if (node.Items != null)
            {
                // validate its children
                if (!Validate(node.Items)
                {
                    return false;
                }
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
