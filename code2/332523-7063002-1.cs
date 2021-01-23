    class DepthFirstEnumerable: IEnumerable<Node>
    {
        private readonly Node _root;
        public DepthFirstEnumerable(Node root)
        {
            _root = root;
        }
        public IEnumerator<Node> GetEnumerator()
        {
            var nodes = new Stack<Node>();
            nodes.Push(_root);
            while (nodes.Any())
            {
                Node node = nodes.Pop();
                yield return node;
                foreach (var n in node.Children) nodes.Push(n);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
