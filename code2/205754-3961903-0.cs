    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                SortedDictionary<string, int> sd = new SortedDictionary<string, int>();
    
                sd.Add("a", 10);
                sd.Add("c", 4);
                sd.Add("b", 20);
    
                Console.WriteLine("___KEYS____");
                foreach (string key in sd.Keys)
                {
                    Console.WriteLine(key);
                }
    
                foreach(int sortedVal in sd.Values.OrderBy(value => value))
                {
                    Console.WriteLine(sortedVal);
                }
            }
        }
    }
