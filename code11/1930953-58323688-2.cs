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
                var groups = tuples.GroupBy(item => item.Item2);
                foreach (var group in groups)
                {
                    foreach (var item in group)
                    {
                        Console.WriteLine(item + ", ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
