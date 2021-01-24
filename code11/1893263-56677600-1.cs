    public class Node
    {
        public int Val { get; set; }
        public IList<Node> Neighbors { get; set; }
        public Node() { }
        public Node(int val, IList<Node> neighbors)
        {
            Val = val;
            Neighbors = neighbors;
        }
        public Node Clone()
        {
            // Start with a shallow copy of this Node using the 'MemberwiseClone` method
            var newNode = (Node)MemberwiseClone();
            // Deep copy the list of neighbors by returning their clones in a new list
            newNode.Neighbors = Neighbors?.Select(node => node.Clone()).ToList();
            // Return our deep copy
            return newNode;
        }
    }
