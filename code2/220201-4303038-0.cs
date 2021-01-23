    public Graph(int numNodes, IList<Tuple<int, int>> edges)
                {
                    Nodes = numNodes;
                    _edges = new IList<int>[numNodes];
    
                    var groups = from e in edges
                                 group e by e.Item1 into g
                                 select new { Key = g.Key, Items = g.Select(s => s.Item2) };
  
    
                    foreach (var grp in groups)
                    {
                        _edges[grp.Key] = grp.Items.ToList();
                    }
                }
