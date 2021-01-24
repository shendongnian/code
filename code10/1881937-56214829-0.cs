    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Polygon
    {
        public IReadOnlyList<(int x, int y)> EndPoints { get; }
        public Polygon(params (int, int)[] endPoints) => EndPoints = endPoints;
    }
    internal static class Program
    {
        private static void Main()
        {
            var data = new[]
            {
                new Polygon((0,1),(2,3),(4,5)),
                new Polygon((0,1),(2,3),(6,7)),
                new Polygon((0,1),(4,5),(6,7)),
            };
            var shareds = data
                .SelectMany(a => data.Where(b => b != a), (a, b) => (a, b))
                .Count(c => c.a.EndPoints.Count(p1 => c.b.EndPoints.Any(p2 => p1 == p2)) >= 2)
                / 2;
            Console.WriteLine(shareds);  //3
        }
    }
