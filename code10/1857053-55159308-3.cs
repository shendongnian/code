    public static List<(long X, long Y)>[] WeightedGraph(long nodeCount, long[][] edges)
    {
        var weightedgraph = new List<(long X, long Y)>[nodeCount + 1];
        for (int i = 0; i < weightedgraph.Length; i++)
        {
            weightedgraph[i] = new List<(long X, long Y)>();
        }
        foreach (var vertex in edges)
        {
            weightedgraph[vertex[0]].Add((1L, 2L));
        }
        return weightedgraph;
    }
