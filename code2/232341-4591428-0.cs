    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {    
        static void Main()
        {
            var dict = new Dictionary<string, string>
            {
                { "X", "first" },
                { "Y", "second" },
                { "Z", "third" }
            };
            // INSERT DICTIONARY-CHANGING CODE HERE            
            
            foreach (var entry in dict)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }
        }
    }
