    static IEnumerable<T> DepthFirstGraphTraversal<T>(
        T root, 
        Func<T, IEnumerable<T>> children)
    {
        var visited = new HashSet<T>();
        var stack = new Stack<T>;
        stack.Push(root);
        while(stack.Count != 0)
        {
            var current = stack.Pop();
            if (!visited.Contains(current))
            {
                visited.Add(current);
                foreach(var child in children(current))
                    stack.Push(child);
                yield return current;
            }
        }
    }
