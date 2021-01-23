    public Node<T> Tree(Queue<T> prefixBank)
    {
        var node = new Node<T>(prefixBank.Dequeue());
        if (isOperator(node))
        {
            for (int i = 0; i < 2; i++)
            {
                node.Add(Tree(prefixBank));
            }
        }
        return node;
    }
