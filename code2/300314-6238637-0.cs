    public class Node
    {
    }
    public class Edge<S, T> : Node
        where S : Node
        where T : Node
    {
        public S Source { get; set; }
        public T Target { get; set; }
    }
