    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var first = new Dictionary<string, int> { { "alex", 10 }, { "liza", 10 }, { "harry", 20 } };
                var second = new Dictionary<string, int> { { "alex", 5 }, { "liza", 4 }, { "harry", 1 } };
                var third = first.ToDictionary(entry => entry.Key, entry => entry.Value);
                foreach (var item in first)
                {
                    third[item.Key] = first[item.Key] - second[item.Key];
                    Console.WriteLine(third[item.Key]);
                }
                Console.Read();
            }
        }
    }
