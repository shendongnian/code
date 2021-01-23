    public IEnumerable<Node> Traverse(Node root)
    {
        // return all the nodes on this level first, before recurring
        foreach (var node in root.Children)
        {
            if (node.Property == someValue)
                yield return node;
        }
    
        // next check children of each node
        foreach (var node in root.Children)
        {
            var children = Traverse(node);
            foreach (var child in children)
            {
                yield return child;
            }
        }
    }
    Parallel.ForEach<Node>(Traverse(n), n => DoSomething(n));
    
