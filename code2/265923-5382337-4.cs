    // Add a node at the beginning of the list with t as its data value.
    public void AddNode(T t)
    {
        Node newNode = new Node();
        newNode.Next = head;
        if (head != null) {
            head.Previous = newNode;
        }
        newNode.Data = t;
        head = newNode;
    }
