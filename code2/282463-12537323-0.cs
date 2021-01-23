    public static IEnumerable<T> DepthFirstTraversal<T>(
        T start,
        Func<T, IEnumerable<T>> getNeighbours)
    {
        var visited = new HashSet<T>();
        var stack = new Stack<T>();
        stack.Push(start);
        
        while (stack.Count != 0)
        {
            var current = stack.Pop();
            visited.Add(current);
            yield return current;
            
            var neighbours = getNeighbours(current).Where(node => !visited.Contains(node));
            
            // If you don't care about the left-to-right order, remove the Reverse
            foreach(var neighbour in neighbours.Reverse())
            {
                stack.Push(neighbour);
            }
        }
    }
