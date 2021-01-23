    public static IEnumerable<Cycle> FindAllCycles()
    {
        HashSet<Node> alreadyVisited = new HashSet<Node>();
        alreadyVisited.Add(Node.AllNodes[0]);
        return FindAllCyclesOptimized(alreadyVisited, Node.AllNodes[0]);
    }
    private static IEnumerable<Cycle> FindAllCycles(HashSet<Node> alreadyVisited, Node a)
    {
        for (int i = 0; i < a.Edges.Count; i++)
        {
            Edge e = a.Edges[i];
            if (alreadyVisited.Contains(e.B))
            {
                yield return new Cycle(e);
            }
            else
            {
                HashSet<Node> newSet = i == a.Edges.Count - 1 ? alreadyVisited : new HashSet<Node>(alreadyVisited);
                newSet.Add(e.B);
                foreach (Cycle c in FindAllCycles(newSet, e.B))
                {
                    c.Build(e);
                    yield return c;
                }
            }
        }
    }
