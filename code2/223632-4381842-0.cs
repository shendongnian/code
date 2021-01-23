    interface Node
    {
        // top level operations here
    }
    
    class OpNode : Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
    
    class AndNode : OpNode
    {
        public AndNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }
        public override string ToString()
        {
            return "(" + Left.ToString() + " & " + Right.ToString() + ")";
        }
    }
    
    class OrNode : OpNode
    {
        public OrNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }
        public override string ToString()
        {
            return "(" + Left.ToString() + " | " + Right.ToString() + ")";
        }
    }
    
    class DataNode<T> : Node
    {
        T _data;
        public DataNode(T data)
        {
            _data = data;
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
