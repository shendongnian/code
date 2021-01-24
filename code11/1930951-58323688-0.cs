    using System;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main()
            {
                (bool, string)[] tuples =
                {
                    (true,  "type1"),
                    (false, "type1"),
                    (true,  "type2"),
                    (false, "type1"),
                    (false, "type2")
                };
                var data = tuples
                   .GroupBy(item => item.Item2)
                   .Select(group => group.ToList())
                   .ToList();
                Console.WriteLine($"Group count = {data.Count}");
                foreach (var list in data)
                {
                    Console.WriteLine(string.Join(", ", list));
                }
            }
        }
    }
