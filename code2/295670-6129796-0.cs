    class Node
    {
        public Node Parent { get; }
        public IEnumerable<Node> Children { get; }
    }
    IEnumerable<Node> Flatten(Node node)
    {
        yield return node;
        foreach (var child in node.Children)
        {
            yield return Flatten(child);
        }
    }
