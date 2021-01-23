    class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
    
        public IEnumerable<Node> GetSubTree()
        {
            return Children.SelectMany(c => c.GetSubTree()).Concat(new[] { this });
        }
    
        public List<Node> Children { get; set; }
        public string Value { get; set; }
    }
    
    class Tree
    {
        public Tree()
        {
            Root = new Node();
        }
        public IEnumerable<Node> GetAllNodes()
        {
            return Root.Children.SelectMany(root => root.GetSubTree()); 
        }
        Node Root { get; set; }
        //This is the Property you want:
        public int GetValuesSum
        {
            get
            {
                return GetAllNodes().Where(node => !string.IsNullOrEmpty(node.Value)).Sum(node => Convert.ToInt32(node.Value));
            }
        }
    }
