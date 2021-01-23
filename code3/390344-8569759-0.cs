    class Node
    {
        int Value { get; set; }
        Node Next { get; set; }
        LinkedList list;
        Node Head { get { return list.Head; } }
        public Node(LinkedList parent)
        {
           this.list = parent;
        }
    }
