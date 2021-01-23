    public static class StemmingUtilities
    {
        private class Node
        {
            public char? Value { get; private set; }
            public Node Parent { get; private set; }
            public List<Node> Children { get; private set; }
            public Node(char? c, Node parent)
            {
                this.Value = c;
                this.Parent = parent;
                this.Children = new List<Node>();
            }
        }
    
        public static string GetRegex(IEnumerable<string> tokens)
        {
            var root = new Node(null,null);
            foreach (var token in tokens)
            {
                var current = root;
                for (int i = 0; i < token.Length; i++)
                {
                    char c = token[i];
                    var node = current.Children.FirstOrDefault(x => x.Value.Value == c);
                    if (node == null)
                    {
                        node = new Node(c,current);
                        current.Children.Add(node);
                    }
                    current = node;
                }   
            }
            return BuildRexp(root);
        }
    
        private static string BuildRexp(Node root)
        {
            string s = "";
            bool addBracket = root.Children.Count > 1;
            // uncomment the following line to avoid first brakets wrapping (occurring in case of multiple root's children)
            // addBracket = addBracket && (root.Parent != null); 
            if (addBracket)
                s += "(";
            for(int i = 0; i < root.Children.Count; i++)
            {
                var child = root.Children[i];
                s += child.Value;
                s += BuildRexp(child);
                if (i < root.Children.Count - 1)
                    s += "|";
            }
            if (addBracket)
                s += ")";
            return s;
        }
    }
