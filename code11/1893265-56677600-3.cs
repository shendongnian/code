    public class Node
    {
        public int Value { get; set; }
        public IList<Node> Neighbors { get; set; }
        public Node() { }
        public Node(int val, IList<Node> neighbors)
        {
            Value = val;
            Neighbors = neighbors;
        }
        public Node Clone()
        {
            // Start with a new node with the same value
            var newNode = new Node { Value = Value };
            // Deep copy the list of neighbors by returning their clones in a new list
            newNode.Neighbors = Neighbors?.Select(node => node.Clone()).ToList();
            // Return our deep copy
            return newNode;
        }
    }
