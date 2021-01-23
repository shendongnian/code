    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var original = new Dictionary<string, string> {
                { "a", "foo" },
                { "b", "bar" },
                { "c", "good" },
                { "d", "bad" },
            };
            
            string needle = "oo";
            
            var filtered = original.Where(d => d.Value.Contains(needle))
                                   .ToDictionary(d => d.Key, d => d.Value);
            
            foreach (var pair in filtered)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
        }
    }
