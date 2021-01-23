    class NodeGetter : INodeGetter
    {
        public Node GetNode(Node parentNode)
        {
            return GetNode(parentNode, this);
        } 
        public Node GetNode(Node parentNode, INodeGetter nodeGetter)
        {
            switch (parentNode.NodeType)
            {
               case NodeType.Multiple:
                   return nodeGetter.GetMultipleNode(parentNode, nodeGetter);
               case NodeType.Repeating:
                   return nodeGetter.GetRepeatingNode(parentNode, nodeGetter);
               default:
                   throw new NotSupportedException(
                       "Node type not supported: " + parentNode.NodeType);
            }
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
