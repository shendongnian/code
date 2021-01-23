    private static IEnumerable<Cycle> FindAllCyclesUnoptimized(HashSet<Node> alreadyVisited, Node a)
    {
        foreach (Edge e in a.Edges)
            if (alreadyVisited.Contains(e.B))
                yield return new Cycle(e);
            else
            {
                HashSet<Node> newSet = new HashSet<Node>(alreadyVisited);
                newSet.Add(e.B);//EDIT: thnx dhsto
                foreach (Cycle c in FindAllCyclesUnoptimized(newSet, e.B))
                {
                    c.Build(e);
                    yield return c;
                }
            }
    }
