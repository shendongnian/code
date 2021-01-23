    static LinkedList<int> GetLinkedList(IList<Node> nodes)
    {
        //null-checks here
        // Build up dictionary from pred to succ.
        var links = nodes.Where(k => k.PredID != null)
                         .ToDictionary(k => k.PredID, k => k.ID);
    
        // Find the root, throw if there are none or multiple.
        var nextId = nodes.Single(k => k.PredID == null).ID;
    
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(nextId);
    
        // Follow the links.
        while (links.TryGetValue(nextId, out nextId))
            linkedList.AddLast(nextId);
    
        return linkedList;
    }
