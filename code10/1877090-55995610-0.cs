    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cNodes = new List<CNode>
                {
                    new CNode{Elements = new List<int>{ 0, 0, 1, 1, 1 } },
                    new CNode{Elements = new List<int>{ 0, 0, 0, 1, 1 } },
                    new CNode{Elements = new List<int>{ 0, 1, 1, 0 } },
                    new CNode{Elements = new List<int>{ 0, 1, 1, 0, 0 } },
                    new CNode{Elements = new List<int>{ 0, 0, 0, 0 } },
                    new CNode{Elements = new List<int>{ 0, 0, 0, 0 } }
                };
    
                Console.WriteLine("\tGroup by 2:");
                foreach (var group in cNodes.GroupByElements(2))
                    Console.WriteLine($"{string.Join("\n", group)}\n");
    
                Console.WriteLine("\tGroup by 3:");
                foreach (var group in cNodes.GroupByElements(3))
                    Console.WriteLine($"{string.Join("\n", group)}\n");
    
                Console.WriteLine("\tGroup by all:");
                foreach (var group in cNodes.GroupByElements())
                    Console.WriteLine($"{string.Join("\n", group)}\n");
            }
        }
    
        static class CNodeExtensions
        {
            public static IEnumerable<IGrouping<IEnumerable<int>, CNode>> GroupByElements(this IEnumerable<CNode> nodes) =>
                nodes.GroupByElements(nodes.Min(node => node.Elements.Count));
    
            public static IEnumerable<IGrouping<IEnumerable<int>, CNode>> GroupByElements(this IEnumerable<CNode> nodes, int count) =>
                nodes.GroupBy(node => node.Elements.Take(count), new SequenceCompare());
    
            private class SequenceCompare : IEqualityComparer<IEnumerable<int>>
            {
                public bool Equals(IEnumerable<int> x, IEnumerable<int> y) => x.SequenceEqual(y);
    
                public int GetHashCode(IEnumerable<int> obj)
                {
                    unchecked
                    {
                        var hash = 17;
                        foreach (var i in obj)
                            hash = hash * 23 + i.GetHashCode();
                        return hash;
                    }
                }
            }
        }    
    
        internal class CNode
        {
            public List<int> Elements;
    
            public override string ToString() => string.Join(", ", Elements);
        }
    }
