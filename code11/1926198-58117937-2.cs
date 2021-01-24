    using System;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main()
            {
                var strings = Enumerable.Range(1, 20).Select(i => i.ToString()).ToList();
                var rng = new Random();
                int n = strings.Count;
                var include = // Create array of bools where half the elements are true and half are false
                    Enumerable.Repeat(true, n/2) // First half is true
                    .Concat(Enumerable.Repeat(false, n-n/2)) // Second half is false
                    .OrderBy(_ => rng.Next()) // Shuffle
                    .ToArray(); 
                var list1 = strings.Where((s, i) =>  include[i]).ToList(); // Take elements where `include[index]` is true
                var list2 = strings.Where((s, i) => !include[i]).ToList(); // Take elements where `include[index]` is false
                Console.WriteLine(string.Join(", ", list1));
                Console.WriteLine(string.Join(", ", list2));
            }
        }
    }
