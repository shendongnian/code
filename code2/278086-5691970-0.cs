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
            Roots = new List<Node>();
        }
    
        public IEnumerable<Node> GetAllNodes()
        {
            return Roots.SelectMany(root => root.GetSubTree()); 
        }
    
        List<Node> Roots { get; set; }
    
        //This is the Property you want:
        public int GetValuesSum
        {
            get
            {
                return GetAllNodes().Where(node => !string.IsNullOrEmpty(node.Value)).Sum(node => Convert.ToInt32(node.Value));
            }
        }
    }
