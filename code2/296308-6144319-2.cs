    class Node<T> 
    {
        protected Node<T> _parent;
        protected List<Node<T>> _children;
        protected T _value;
        protected Node() { }
        
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
        //Naughty nodes dont have parents, only kids
        public NaughtyNode(int value)
        {
            _value = value;
            _children = new List<Node<T>>();
        }
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
