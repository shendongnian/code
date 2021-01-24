csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Vertex = System.ValueTuple<double,double,double>;
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
            string file = args[0];
            Vertex[][] triangles = ParseStl(file);
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
                // Mark 0-th vertexes connected component as connected to those of all other vertices.
                foreach (int v in triangle.Skip(1))
                {
                    du.Union(vertex0, v);
                }
            }
            var connectedComponents =
                new HashSet<int>(Enumerable.Range(0, vertexCount).Select(x => du.Find(x)));
            int count = connectedComponents.Count;
            Console.WriteLine($"Number of connected components: {count}.");
            var groups = triangles.GroupBy(t => du.Find(indexedVertices[t[0]]));
            foreach (IGrouping<int, Vertex[]> g in groups)
            {
                Console.WriteLine($"Group id={g.Key}:");
                foreach (Vertex[] triangle in g)
                {
                    string tr = string.Join(' ', triangle);
                    Console.WriteLine($"\t{tr}");
                }
            }
        }
        private static Regex _triangleStart = new Regex(@"^\s+outer loop");
        private static Regex _triangleEnd = new Regex(@"^\s+endloop");
        private static Regex _vertex = new Regex(@"^\s+vertex\s+(\S+)\s+(\S+)\s+(\S+)");
        private static Vertex[][] ParseStl(string file)
        {
            double ParseCoordinate(GroupCollection gs, int i) =>
                double.Parse(gs[i].Captures[0].Value, CultureInfo.InvariantCulture);
            var triangles = new List<Vertex[]>();
            bool isInsideTriangle = false;
            List<Vertex> triangle = new List<Vertex>();
            foreach (string line in File.ReadAllLines(file))
            {
                if (isInsideTriangle)
                {
                    if (_triangleEnd.IsMatch(line))
                    {
                        isInsideTriangle = false;
                        triangles.Add(triangle.ToArray());
                        triangle = new List<Vertex>();
                        continue;
                    }
                    Match vMatch = _vertex.Match(line);
                    if (vMatch.Success)
                    {
                        double x1 = ParseCoordinate(vMatch.Groups, 1);
                        double x2 = ParseCoordinate(vMatch.Groups, 2);
                        double x3 = ParseCoordinate(vMatch.Groups, 3);
                        triangle.Add((x1, x2, x3));
                    }
                }
                else
                {
                    if (_triangleStart.IsMatch(line))
                    {
                        isInsideTriangle = true;
                    }
                }
            }
            return triangles.ToArray();
        }
    }
}
I'm also using the fact that `System.ValueTuple` implements `Equals` and `GetHashCode` in an appropriate way, so we can easily compare vertices (this is used implicitly by `HashSet`) and use them as keys in a dictionary.
