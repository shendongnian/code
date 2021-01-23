    public sealed class Node
    {
        public static readonly ReadOnlyCollection<Node> AllNodes;
        internal static readonly List<Node> allNodes;
        static Node()
        {
            allNodes = new List<Node>();
            AllNodes = new ReadOnlyCollection<Node>(allNodes);
        }
        public static void SetReferences()
        {//call this method after all nodes have been created
            foreach (Edge e in Edge.AllEdges)
                e.A.edge.Add(e);
        }
        
        //All edges linking *from* this node, not to it. 
        //The variablename "Edges" it quite unsatisfactory, but I couldn't come up with anything better.
        public ReadOnlyCollection<Edge> Edges { get; private set; }
        internal List<Edge> edge;
        public int Index { get; private set; }
        public Node(params int[] nodesIndicesConnectedTo)
        {
            this.edge = new List<Edge>(nodesIndicesConnectedTo.Length);
            this.Edges = new ReadOnlyCollection<Edge>(edge);
            this.Index = allNodes.Count;
            allNodes.Add(this);
            foreach (int nodeIndex in nodesIndicesConnectedTo)
                new Edge(this, nodeIndex);
        }
        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
    public sealed class Edge
    {
        public static readonly ReadOnlyCollection<Edge> AllEdges;
        static readonly List<Edge> allEdges;
        static Edge()
        {
            allEdges = new List<Edge>();
            AllEdges = new ReadOnlyCollection<Edge>(allEdges);
        }
        public int Index { get; private set; }
        public Node A { get; private set; }
        public Node B { get { return Node.allNodes[this.bIndex]; } }
        private readonly int bIndex;
        internal Edge(Node a, int bIndex)
        {
            this.Index = allEdges.Count;
            this.A = a;
            this.bIndex = bIndex;
            allEdges.Add(this);
        }
        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
    public sealed class Cycle
    {
        public readonly ReadOnlyCollection<Edge> Members;
        private List<Edge> members;
        private bool IsComplete;
        internal void Build(Edge member)
        {
            if (!IsComplete)
            {
                this.IsComplete = member.A == members[0].B;
                this.members.Add(member);
            }
        }
        internal Cycle(Edge firstMember)
        {
            this.members = new List<Edge>();
            this.members.Add(firstMember);
            this.Members = new ReadOnlyCollection<Edge>(this.members);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var member in this.members)
            {
                result.Append(member.Index.ToString());
                if (member != members[members.Count - 1])
                    result.Append(", ");
            }
            return result.ToString();
        }
    }
