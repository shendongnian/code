    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
        static void Main(string[] args)
        {
            var input = new List<string>{"a","b","c","at","h","c","bt"};
            
            int tCounter = 0;
            var groups = input.GroupBy(x => x.Contains("t") ? ++tCounter : tCounter)
                              .Select(group => group.ToList())
                              .ToList();
            foreach (var list in groups)
            {
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }
