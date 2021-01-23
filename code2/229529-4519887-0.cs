    private class Node
    {
        public string Value { get; private set; }
        public Node Parent { get; private set; }
        public List<Node> Children { get; private set; }
        public Node(string c, Node parent)
        {
            this.Value = c;
            this.Parent = parent;
            this.Children = new List<Node>();
        }
        public override string ToString()
        {
            return "Value: " + this.Value;
        }
    }
    
    private static Node BuildTree(IEnumerable<string> tokens, char[] sep)
    {
        var root = new Node(null, null);
        foreach (var token in tokens)
        {
            var current = root;
            var splits = token.Split(sep);
            for (int i = 0; i < splits.Length; i++)
            {
                string split = splits[i];
                var node = current.Children.FirstOrDefault(x => x.Value == split);
                if (node == null)
                {
                    node = new Node(split, current);
                    current.Children.Add(node);
                }
                current = node;
            }
        }
        return root;
    }
