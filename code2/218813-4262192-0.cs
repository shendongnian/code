    public class Node 
    { 
        public Node(object data) 
        { 
            this.Data = obj;
        }
        public object Data { get; protected set; }
    }
    public class Node<T> : Node
    {
        public Node(T data) : base(data) { }
        new public T Data 
        {
            get { return (T)base.Data; }
        }
    }
 
