    class NodeGetter : INodeGetter
    {
        public Node GetNode(Node parentNode)
        {
            return GetNode(parentNode, this);
        } 
        public Node GetNode(Node parentNode, INodeGetter nodeGetter)
        {
            Node node = new Node();
    
            switch (parentNode.NodeType)
            {
               case NodeType.Multiple:
                   node = GetMultipleNode(parentNode, nodeGetter);
                   break;
               case NodeType.Repeating:
                   node = GetRepeatingNode(parentNode, nodeGetter);
                   break;
            }
    
            return node;
        }
    
        public Node GetMultipleNode(Node parentNode, INodeGetter nodeGetter)
        {
            foreach (Node child in parentNode.Children)
            {
                return nodeGetter.GetNode(child);
            }
        }
    
        public Node GetRepeatingNode(Node parentNode, INodeGetter nodeGetter)
        {
            for (int i = 0; i < parentNode.Count; i++)
            {
                // Assume meaningful constructor for Node
                return nodeGetter.GetNode(new Node(i));
            }
        }
    }
