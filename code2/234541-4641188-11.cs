    public static LinkedList<int> GetLinkedList(IEnumerable<Node> nodes)
    {
        if(nodes == null)
           throw new ArgumentNullException("nodes");
        return new LinkedList<int>(GetOrderedNodes(nodes.ToList()));
    }
    private static IEnumerable<int> GetOrderedNodes(IEnumerable<Node> nodes)
    {
        // Build up dictionary from pred to succ.
        var links = nodes.Where(k => k.PredID != null)
                         .ToDictionary(k => k.PredID, k => k.ID);
        // Find the head, throw if there are none or multiple.
        var nextId = nodes.Single(k => k.PredID == null).ID;
        // follow the links
        do
        {
            yield return nextId;
        } while (links.TryGetValue(nextId, out nextId));
    }
