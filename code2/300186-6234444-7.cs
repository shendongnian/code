    public static IEnumerable<T> Preorder<T>(Node<T> root)
    {
        var stack = new Stack<Node<T>>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            yield return node.Data;
            if (node.RightChild != null)
                stack.Push(node.RightChild);
            if (node.LeftChild != null)
                stack.Push(node.LeftChild);
        }
    }
