    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(string.Join("\r\n", uniquePaths.Select(z => z.Item1 + " " + z.Item2)));
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    
        private static List<(string, int)> flattenedPaths = new List<(string, int)>
            {
                    ("1->2", 0),
                    ("1->2->3", 1),
                    ("1->2->3->4", 2),
                    ("5->6", 3),
                    ("5->6->7", 4),
                    ("5->6->7->8", 5),
            };
    
        private static IEnumerable<(string, int)> uniquePaths = GetUniquePaths(flattenedPaths);
    
        private static IEnumerable<(string, int)> GetUniquePaths(List<(string, int)> Paths)
        {
            var betterData = Paths
                .Select(z => new
                {
                    Number = z.Item2,
                    Value = z.Item1,
                    Lower = int.Parse(z.Item1.Substring(0, z.Item1.IndexOf("-"))),
                    Upper = int.Parse(z.Item1.Substring(z.Item1.LastIndexOf("-") + 2))
                })
                .OrderByDescending(z => z.Value.Length).ThenByDescending(z => z.Upper).ThenBy(z => z.Lower).ToList();
    
            foreach (var entry in betterData.ToList())
            {
                betterData.RemoveAll(z => z != entry && z.Lower >= entry.Lower && z.Upper <= entry.Upper);
            }
    
            return betterData.Select(x => (x.Value, x.Number));
        }
    }
