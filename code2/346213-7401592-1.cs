    var groups = eqList.GroupBy(n => n.RootID).Where(g => g.Count() >= 3);
    
    foreach (var g in groups) {
        Console.Out.WriteLine("There are {0} nodes which share RootId = {1}",
                              g.Count(), g.Key);
        foreach (var node in g) {
            Console.Out.WriteLine("    node id = " + node.ID);
        }
    }
