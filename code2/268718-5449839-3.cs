    public Node<T> Tree(IEnumerable<T> prefixBank)
    {
        return Tree(prefixBank.GetEnumerator());
    }
    public Node<T> Tree(IEnumerator<T> enumerator)
    {
        enumerator.MoveNext();
        var value = enumerator.Current;
        var children = new List<Node<T>>(2);
        if (isOperator(value))
        {
            for (int i = 0; i < 2; i++)
            {
                children.Add(Tree(enumerator));
            }
        }
        return new Node<T>(value, children);
    }
