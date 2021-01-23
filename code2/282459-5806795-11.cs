    public static IEnumerable<Vertex> DepthFirstTraversal(
        this IGraph graph, 
        Vertex start) 
    {
        var visited = new HashSet<Vertex>();
        var stack = new Stack<Vertex>();
        stack.Push(start);
        while(stack.Count != 0)
        {
            var current = stack.Pop();
            if(!visited.Contains(current))
                yield return current;
            visited.Add(current);
            var neighbours = graph.GetNeighbours(current)
                                  .Where(n=>!visited.Contains(n));
            // If you don't care about the left-to-right order, remove the Reverse
            foreach(var neighbour in neighbours.Reverse()) 
                stack.Push(neighbour);
        }
    }
