    public class Node
    {
        public Node(IGraphData data)
        {
            this.Data = obj;
        }
        public IGraphData Data { get; protected set; }
    }
    public class Node<T> : Node where T : IGraphData
    {
        public Node(T data) : base(data) { }
        new public T Data
        {
            get { return (T)base.Data; }
        }
    }
    public class Edge
    {
    }
    public class Edge<T, U> : Edge
        where T : Node where U : Node
    {
        // ...
    }
