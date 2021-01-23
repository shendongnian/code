    public static Dictionary<Node, int> GetLevelsForNodes(IEnumerable<Node> nodes)
    {
        //argument-checking omitted.
 
        // Thankfully, lookup accepts null-keys.
        var nodesByParentId = nodes.ToLookup(n => n.ParentID);
    
        var levelsForNodes = new Dictionary<Node, int>();
         
        // Singleton list comprising the root.
        var nodesToProcess = nodesByParentId[null].ToList();
        int currentLevel = 0;
    
        while (nodesToProcess.Any())
        {
            foreach (var node in nodesToProcess)
                levelsForNodes.Add(node, currentLevel);
    
            nodesToProcess = nodesToProcess.SelectMany(n => nodesByParentId[n.Id])
                                           .ToList();
            currentLevel++;
        }
    
        return levelsForNodes;
    }
