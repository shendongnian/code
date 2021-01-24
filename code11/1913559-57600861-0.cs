    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace ConsoleApp12
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var list = new SortedList<string, SomeClass>
                {
                    ["aa"] = new SomeClass { Key = "aa" },
                    ["bb"] = new SomeClass { Key = "bb" },
                    ["cc"] = new SomeClass { Key = "cc" },
                    ["dd"] = new SomeClass { Key = "dd" }
                };
    
                var ids = new List<string> { "bb", "cc" };
    
                var results = ids.Select(x =>
                {
                    list.TryGetValue(x, out var matching);
                    return matching;
                }).Where(z => z != null);
    
                // Output to show the results
                Console.WriteLine(string.Join(",", results.Select(z => z.Key)));
            }
        }
    }
