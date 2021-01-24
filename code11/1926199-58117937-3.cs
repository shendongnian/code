    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main()
            {
                var strings = Enumerable.Range(1, 20).Select(n => n.ToString()).ToList();
                var list1 = new List<string>();
                var list2 = new List<string>();
                var rng       = new Random();
                int available = strings.Count;
                int remaining = available / 2;
                foreach (var s in strings)
                {
                    if (rng.NextDouble() < remaining / (double) available)
                    {
                        list1.Add(s);
                        --remaining;
                    }
                    else
                    {
                        list2.Add(s);
                    }
                    --available;
                }
                Console.WriteLine(string.Join(", ", list1));
                Console.WriteLine(string.Join(", ", list2));
            }
        }
    }
