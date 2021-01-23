    class LinearCollection<T, NodeType> where NodeType : NodeElement<T>, new()
    {
        public bool Add(T element)
        {
            if (head == null)
            {
                head = new NodeType();
                head.Value = element;
            }
            ...
        }
    }
