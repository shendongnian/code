    if (bag.TryTake(out node))
    {
        for (int i = 0; i < node.Children.Count; i++)
        {
            bag.Add(node.Children[i]);
        }
    
        ProcessNode(node); //e.g. a short string comparison
    }
