    public Graph(int numNodes, IList<Tuple<int, int>> edges)
    {
        Nodes = numNodes;
        _edges = Enumerable.Range(0, numNodes).Select(num =>
                        edges.Where(x => x.Item1 == num).Select(x => x.Item2)
                                .Union(edges.Where(x => x.Item2 == num).Select(x => x.Item1))
                                .Distinct().ToList() as IList<int>
            ).ToList();
    }
