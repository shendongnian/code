    public static int ShortestDistance(Graph graph, Node from, Node to)
    {
        var distances = new Dictionary<Node, int>();
        var actualNodes = graph.GetNodes() as List<Node> ?? Graph.GetNodes().ToList();
    
        foreach (var node in actualNodes) distances[node] = int.MaxValue;
    
        foreach (var adjacent in graph.GetAdjacentsByNode(from))
        {
            distances[adjacent.To] = adjacent.Weight;
        }
    
        while (actualNodes.Count() != 0)
        {
            var actualShortest = actualNodes.OrderBy(n => distances[n]).First();
            actualNodes.Remove(actualShortest);
    
            if (distances[actualShortest] == int.MaxValue) break;
    
            if (actualShortest.Equals(to)) return distances[actualShortest];
    
            foreach (var adjacent in graph.GetAdjacentsByNode(actualShortest))
            {
                var actualDistance = distances[actualShortest] + adjacent.Weight;
                if (actualDistance >= distances[adjacent.To]) continue;
                distances[adjacent.To] = actualDistance;
            }
        }
    
        throw new Exception($"There's no such route from '{from}' to '{to}'.");
    }
