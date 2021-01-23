    private void DoSomethingWithAllNodesByType(int NodeId, string typeName)
    {
        var node = new Node(nodeId);
        foreach (Node childNode in node.Children)
        {
            var child = childNode;
            if (child.NodeTypeAlias == typeName)
            {
                //Do something
            }
            if (child.Children.Count > 0)
                GetAllNodesByType(child, typeName);
        }
    }
