    static LinkedList<int> GetLinkedList(IEnumerable<Node> nodes)
    {
        return new LinkedList<int>(nodes.OrderBy(node => GetIndex(nodes, node))
                                        .Select(node => node.ID));
    }
    static int GetIndex(IEnumerable<Node> nodes, Node node)
    {
        return node.PredID == null ? 0 :
               1 + GetIndex(nodes, nodes.Single(n => n.ID == node.PredID));
    }
