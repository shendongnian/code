    public class Vertex
    {
        public int Id { get;set; }
        public int Index { get; set; }
        public int Lowlink { get; set; }
        public HashSet<Vertex> Dependencies { get; set; }
        public Vertex()
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
            Dependencies = new HashSet<Vertex>();
        }
        public override string ToString()
        {
            return string.Format("Vertex Id {0}", Id);
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Vertex other = obj as Vertex;
            if (other == null)
                return false;
            return Id == other.Id;
        }
    }
    public class TarjanCycleDetectStack
    {
        protected List<List<Vertex>> _StronglyConnectedComponents;
        protected Stack<Vertex> _Stack;
        protected int _Index;
        public List<List<Vertex>> DetectCycle(List<Vertex> graph_nodes)
        {
            _StronglyConnectedComponents = new List<List<Vertex>>();
            _Index = 0;
            _Stack = new Stack<Vertex>();
            foreach (Vertex v in graph_nodes)
            {
                if (v.Index < 0)
                {
                    StronglyConnect(v);
                }
            }
            return _StronglyConnectedComponents;
        }
        private void StronglyConnect(Vertex v)
        {
            v.Index = _Index;
            v.Lowlink = _Index;
            _Index++;
            _Stack.Push(v);
            foreach (Vertex w in v.Dependencies)
            {
                if (w.Index < 0)
                {
                    StronglyConnect(w);
                    v.Lowlink = Math.Min(v.Lowlink, w.Lowlink);
                }
                else if (_Stack.Contains(w))
                {
                    v.Lowlink = Math.Min(v.Lowlink, w.Index);
                }
            }
            if (v.Lowlink == v.Index)
            {
                List<Vertex> cycle = new List<Vertex>();
                Vertex w;
                do
                {
                    w = _Stack.Pop();
                    cycle.Add(w);
                } while (v != w);
                _StronglyConnectedComponents.Add(cycle);
            }
        }
    }
        [TestMethod()]
        public void TarjanStackTest()
        {
            // tests simple model presented on https://en.wikipedia.org/wiki/Tarjan%27s_strongly_connected_components_algorithm
            var graph_nodes = new List<Vertex>();
            var v1 = new Vertex() { Id = 1 };
            var v2 = new Vertex() { Id = 2 };
            var v3 = new Vertex() { Id = 3 };
            var v4 = new Vertex() { Id = 4 };
            var v5 = new Vertex() { Id = 5 };
            var v6 = new Vertex() { Id = 6 };
            var v7 = new Vertex() { Id = 7 };
            var v8 = new Vertex() { Id = 8 };
            v1.Dependencies.Add(v2);
            v2.Dependencies.Add(v3);
            v3.Dependencies.Add(v1);
            v4.Dependencies.Add(v3);
            v4.Dependencies.Add(v5);
            v5.Dependencies.Add(v4);
            v5.Dependencies.Add(v6);
            v6.Dependencies.Add(v3);
            v6.Dependencies.Add(v7);
            v7.Dependencies.Add(v6);
            v8.Dependencies.Add(v7);
            v8.Dependencies.Add(v5);
            v8.Dependencies.Add(v8);
            graph_nodes.Add(v1);
            graph_nodes.Add(v2);
            graph_nodes.Add(v3);
            graph_nodes.Add(v4);
            graph_nodes.Add(v5);
            graph_nodes.Add(v6);
            graph_nodes.Add(v7);
            graph_nodes.Add(v8);
            var tcd = new TarjanCycleDetectStack();
            var cycle_list = tcd.DetectCycle(graph_nodes);
            Assert.IsTrue(cycle_list.Count == 4);
        }
