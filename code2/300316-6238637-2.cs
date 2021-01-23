    public class Node
    {
    }
    public class Edge<S, T>
        where S : Node
        where T : Node
    {
        public S Source { get; set; }
        public T Target { get; set; }
    }
