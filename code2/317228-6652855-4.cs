    void AttachOrAddChildren(Node node)
    {
        if (node.Children != null)
        {
            foreach(var child in node.Children)
            {
                if (child.ID > 0)
                    context.Nodes.Attach(child);
                else
                    context.Nodes.Add(child);
                AttachOrAddChildren(child);
            }
        }
    }
