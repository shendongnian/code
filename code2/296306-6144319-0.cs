    class Node<T> 
    {
        protected Node<T> _parent;
        internal List<Node<T>> _children;
        internal T _value;
        internal Node() { }
        
        public Node(T value)
        {
            _parent = null;
            _value = value;
            _children = new List<Node<T>>();
        }
        public void AddChild(Node<T> child) 
        {            
            child._parent = this;
            _children.Add(child);
        }
    }
    class NaughtyNode : Node<int>
    {
        public void BeNaughty()
        {
            Node<int> victim = new Node<int>(1);
            victim._parent = this; //Does not work, cannot access
        }
        public void AddChild(NaughtyNode child)
        {
            _children.Add(child);
        }
    }
