    static class NodeExtensions
    {
        public static IEnumerable<Node> Descendants(this Node node)
        {
            return node.Children.Concat(node.Children.SelectMany(n => n.Descendants()));
        }
    }
