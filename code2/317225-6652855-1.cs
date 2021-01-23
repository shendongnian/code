    if (childNode.ID > 0)
        context.Nodes.Attach(childNode);
    Node newParentNode = new Node()
    {
        Children = new List<Node>()
        {
            childNode
        }
    };
    context.Nodes.Add(newParentNode);
    context.SaveChanges();
