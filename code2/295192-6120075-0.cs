    public class Node
    {
        public string Name {get; private set;}
        public List<Node> Children {get;set;}
        public Node Parent {get; private set}
        public Node(string name, Node parent)
        {
            this.Name = name;
            this.Children = new List<Node>();
            this.Parent = parent;
        }
    }
