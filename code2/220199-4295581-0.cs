    public class Graph2
    {
        private IList<HashSet<int>> _edges;
        public int Nodes { get; private set; }
        public Graph2(int numNodes, IList<Tuple<int, int>> edges)
        {
            Nodes = numNodes;
            _edges = new List<HashSet<int>>(numNodes);
            for (int i = 0; i < numNodes; i++)
            {
                _edges.Add(new HashSet<int>());
            }
            foreach (var edge in edges)
            {
                _edges[edge.Item1].Add(edge.Item2);
                _edges[edge.Item2].Add(edge.Item1);
            }
        }
        public IEnumerable<int> Neighbors(int node)
        {
            return _edges[node];
        }
    }
