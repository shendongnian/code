    public class Graph
            {
                private IList<IEnumerable<int>> _edges;
    
                public int Nodes { get; private set; }
    
                public Graph(int numNodes, IList<Tuple<int, int>> edges)
                {
                    Nodes = numNodes;
                    _edges = new IList<int>[numNodes];
    
                    var groups = from e in edges
                                 group e by e.Item1 into g
                                 select g;
    
    
                    foreach (var grp in groups)
                    {
                        _edges[grp.Key] = (from g in grp
                                           select g.Item2).ToList();
                    }
                }
    
                public IEnumerable<int> Neighbors(int node)
                {
                    return _edges[node];
                }
            }
