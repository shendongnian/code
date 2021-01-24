csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Vertex = System.ValueTuple<int,int,int>;
namespace UnionFindSample
{
    internal class DisjointUnionSets
    {
        private readonly int _n;
        private readonly int[] _rank;
        private readonly int[] _parent;
        public DisjointUnionSets(int n)
        {
            _rank = new int[n];
            _parent = new int[n];
            _n = n;
            MakeSet();
        }
        // Creates n sets with single item in each
        public void MakeSet()
        {
            for (var i = 0; i < _n; i++)
                // Initially, all elements are in
                // their own set.
                _parent[i] = i;
        }
        // Finds the representative of the set
        // that x is an element of.
        public int Find(int x)
        {
            if (_parent[x] != x)
            {
                // if x is not the parent of itself, then x is not the representative of
                // his set.
                // We do the path compression by moving x’s node directly under the representative
                // of this set.
                _parent[x] = Find(_parent[x]);
            }
            return _parent[x];
        }
        // Unites the set that includes x and
        // the set that includes x
        public void Union(int x, int y)
        {
            // Find representatives of two sets.
            int xRoot = Find(x), yRoot = Find(y);
            // Elements are in the same set, no need to unite anything.
            if (xRoot == yRoot)
            {
                return;
            }
            if (_rank[xRoot] < _rank[yRoot])
            {
                // Then move x under y so that depth of tree remains equal to _rank[yRoot].
                _parent[xRoot] = yRoot;
            }
            else if (_rank[yRoot] < _rank[xRoot])
            {
                // Then move y under x so that depth of tree remains equal to _rank[xRoot].
                _parent[yRoot] = xRoot;
            }
            else
            {
                // if ranks are the same
                // then move y under x (doesn't matter which one goes where).
                _parent[yRoot] = xRoot;
                // And increment the result tree's
                // rank by 1
                _rank[xRoot] = _rank[xRoot] + 1;
            }
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vertex[][] triangles =
            {
                // Component 1, triangle 1.
                new[] {(0, 0, 0), (1, 1, 1), (2, 2, 2)},
                // Component 1, triangle 2.
                new[] {(0, 0, 0), (1, 1, 1), (3, 3, 3)},
                // Component 2, triangle 1.
                new[] {(4, 4, 4), (5, 5, 5), (6, 6, 6)},
                // Component 2, triangle 2. Connected to triangle 1 in only one vertex.
                new[] {(4, 4, 4), (7, 7, 7), (8, 8, 8)}
            };
            var uniqueVertices = new HashSet<Vertex>(triangles.SelectMany(t => t));
            int vertexCount = uniqueVertices.Count;
            // The DisjointUnionSets class works with integers, so we need a map from vertex
            // to integer (its id).
            Dictionary<Vertex, int> indexedVertices = uniqueVertices
                .Zip(
                    Enumerable.Range(0, vertexCount),
                    (v, i) => new {v, i})
                .ToDictionary(vi => vi.v, vi => vi.i);
            int[][] indexedTriangles =
                triangles
                .Select(t => t.Select(v => indexedVertices[v]).ToArray())
                .ToArray();
            var du = new DisjointUnionSets(vertexCount);
            // Iterate over the "triangles" consisting of vertex ids.
            foreach (int[] triangle in indexedTriangles)
            {
                int vertex0 = triangle[0];
                int vertex1 = triangle[1];
                int vertex2 = triangle[2];
                // Mark 0-th vertexes connected component as connected to 1th and 2nd.
                du.Union(vertex0, vertex1);
                du.Union(vertex0, vertex2);
            }
            var connectedComponents =
                new HashSet<int>(Enumerable.Range(0, vertexCount).Select(x => du.Find(x)));
            int count = connectedComponents.Count;
            Console.WriteLine($"Number of connected components: {count}.");
        }
    }
}
I'm also using the fact that `System.ValueTuple` implements `Equals` and `GetHashCode` in an appropriate way, so we can easily compare vertices (this is used implicitly by `HashSet`) and use them as keys in a dictionary.
