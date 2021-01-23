            public static bool DepthFirstSearch<T>(this IEnumerable<T> vertices, T rootVertex, T targetVertex, Func<T, IEnumerable<T>> getConnectedVertices, Func<T, T, bool> matchFunction = null)
        {
            if (getConnectedVertices == null)
            {
                throw new ArgumentNullException("getConnectedVertices");
            }
            if (matchFunction == null)
            {
                matchFunction = (t, u) => object.Equals(t, u);
            }
            var directlyConnectedVertices = getConnectedVertices(rootVertex);
            foreach (var vertex in directlyConnectedVertices)
            {
                if (matchFunction(vertex, targetVertex))
                {
                    return true;
                }
                else if (vertices.DepthFirstSearch(vertex, targetVertex, getConnectedVertices, matchFunction))
                {
                    return true;
                }
            }
            return false;
        }
