    static LinkedList<int> GetLinkedList(IList<Node> nodes)
    {
        //null-checks here
        // build up dictionary from pred to succ
        var edges = nodes.Where(k => k.PredID != null)
                         .ToDictionary(k => k.PredID, k => k.ID);
    
        // Find the root, throw if there are none on multiple.
        var nextId = nodes.Single(k => k.PredID == null).ID;
    
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(nextId);
    
        // Follow the edges
        while (edges.TryGetValue(nextId, out nextId))
            linkedList.AddLast(nextId);
    
        return linkedList;
    }
