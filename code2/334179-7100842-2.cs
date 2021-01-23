    public void Traverse(Node root, bool parallel = true)
    {
        if (node.Property == someValue)
            DoSomething(node);
        if (parallel)
        {
            Parallel.ForEach(node.Children, node =>
            {
                Traverse(node, false);
            });
        }
        else
        {
            foreach (var node in node.Children)
            {
                Traverse(node, false);
            }
        }
    }
