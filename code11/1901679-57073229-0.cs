    public static T[] GetVerticesFromEdges<T>((T, T)[] edges,
        IEqualityComparer<T> comparer)
    {
        if (edges.Length == 0) return new T[0];
        var vertices = new Dictionary<T, List<T>>(comparer);
        void AddVertex(T vertex, T connectedVertex)
        {
            if (!vertices.TryGetValue(vertex, out var connectedVertices))
            {
                connectedVertices = new List<T>();
                vertices[vertex] = connectedVertices;
            }
            connectedVertices.Add(connectedVertex);
        }
        foreach (var edge in edges)
        {
            AddVertex(edge.Item1, edge.Item2);
            AddVertex(edge.Item2, edge.Item1);
        }
        var invalid = vertices.Where(e => e.Value.Count != 2).Select(e => e.Key);
        if (invalid.Any())
        {
            throw new InvalidDataException(
                "Vertices [" + String.Join(", ", invalid) +
                "] are not connected with exactly 2 other vertices.");
        }
        var output = new List<T>();
        var currentVertex = vertices.Keys.First();
        while (true)
        {
            output.Add(currentVertex);
            var connectedVertices = vertices[currentVertex];
            vertices.Remove(currentVertex);
            if (vertices.ContainsKey(connectedVertices[0]))
            {
                currentVertex = connectedVertices[0];
            }
            else if (vertices.ContainsKey(connectedVertices[1]))
            {
                currentVertex = connectedVertices[1];
            }
            else
            {
                break;
            }
        }
        if (vertices.Count > 0)
        {
            throw new InvalidDataException(
                "Vertices [" + String.Join(", ", vertices.Keys) +
                "] are not connected with the rest of the graph.");
        }
        return output.ToArray();
    }
