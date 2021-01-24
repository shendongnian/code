    public class Graph
    {
        public Dictionary<int,List<int>>_adjacencyList; 
        public Graph(int[,] edges)
        {
            _adjacencyList = edges.Cast<int>().Distinct().ToDictionary(v => v, v => new List<int>());
            for (int i = 0; i < edges.GetLength(0); ++i)
                _adjacencyList[edges[i, 0]].Add(edges[i, 1]);
        }
        private void visit(int v , Stack<int> S, Stack<int> P, Dictionary<int, int> preorder, Dictionary<int, List<int>> components, ref int c)
        {
            preorder[v] = c++;
            S.Push(v);
            P.Push(v);
            foreach(var w in _adjacencyList[v])
            {
                if (!preorder.ContainsKey(w))
                    visit(w, S, P, preorder, components, ref c);
                else if (! components.ContainsKey(w))
                    while (preorder[P.Peek()] > preorder[w])
                        P.Pop();
            }
            if (v == P.Peek())
            {
                List<int> component = new List<int>();
                do {
                    component.Add(S.Pop());
                } while (component.Last() != v);
                P.Pop();
                foreach (int i in component)
                    components[i] = component;
            }
        }
        public List<List<int>> GetStronglyConnectedComponents()
        {
            var components = new Dictionary<int, List<int>>();
            var unassigned = new Stack<int>();
            var undetermined = new Stack<int>();
            var preorder = new Dictionary<int, int>();
            var counter = 0;
            foreach (int vert in _adjacencyList.Keys)
                if (!preorder.ContainsKey(vert))
                    visit(vert, unassigned, undetermined, preorder, components, ref counter);
            return components.Values.Distinct().ToList();
        }
    };
    static void Main(string[] args)
    {
        Graph g = new Graph(
                new int[,]
                {
                    {1, 4 },
                    {1 ,5 },
                    {2 ,3 },
                    {2 ,1 },
                    {3 ,2 },
                    {4 ,3 },
                    {5 ,7 },
                    {5 ,6 },
                    {6 ,8 },
                    {8 ,12},
                    {7 ,9 },
                    {9 ,7 },
                    {9 ,11},
                    {9 ,10},
                    {10,8 },
                    {10,7 }
                }
            );
        var output = g.GetStronglyConnectedComponents();
        foreach (var component in output)
            System.Console.WriteLine( "{" + String.Join(" , ", component) + "}");
    }
