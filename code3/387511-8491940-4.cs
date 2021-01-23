    private bool Validate(ITreeCollection items)
    {
        foreach (TreeNodeBase node in (IEnumerable) items)
        {
            // validate the node itself first
            if (!Validate((dynamic) node)) // this will call the most appropriate version of Validate
            {
                return false;
            }
            if (node.Items != null)
            {
                // validate its children
                if (!Validate(((TreeNodeBase) itm).Items)
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool Validate(BananaNode node)
    {
        //TODO do BananaNode specific validation
    }
    private bool Validate(AppleNode node)
    {
        //TODO do AppleNode specific validation
    }
    private bool Validate(TreeNodeBase node)
    {
        throw new ArgumentOutOfRangeException("Cannot validate node of type '" + node.GetType().Name + "'.");
    }
