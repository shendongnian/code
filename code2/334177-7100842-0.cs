    public void Traverse(Node root)
    {
        if (node.Property == someValue)
            DoSomething(node);
        var tasks = new List<Task>();
        foreach (var node in node.Children)
        {
            // tmp is necessary because of the way closures close over loop variables
            var tmp = node;
            tasks.Add(Task.Factory.StartNew(() => Traverse(tmp)));
        }
        Task.WaitAll(tasks.ToArray());
    }
