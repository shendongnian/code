    public static LinkedList<int> GetLinkedList(IEnumerable<Node> nodes)
    {
        if(nodes == null)
           throw new ArgumentNullException("nodes");
        return new LinkedList<int>(GetOrderedNodes(nodes.ToList()));
    }
    private static IEnumerable<int> GetOrderedNodes(IEnumerable<Node> nodes)
    {
        // Build up dictionary from pred to succ.
        var links = nodes.Where(node => node.PredID != null)
                         .ToDictionary(node => node.PredID, node => node.ID);
        // Find the head, throw if there are none or multiple.
        var nextId = nodes.Single(node => node.PredID == null).ID;
        // Follow the links.
        do
        {
            yield return nextId;
        } while (links.TryGetValue(nextId, out nextId));
    }
