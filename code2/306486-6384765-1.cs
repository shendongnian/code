    using System;
    using System.Collections.Generic;
    
    class Test
    { 
        static void Main() 
        {
            var test = new Dictionary<int, string>();
            test.Add(3, "three");
            test.Add(2, "two");
            test.Add(1, "one");
            test.Add(0, "zero");
            
            test.Remove(2);
            test.Add(5, "five");
            
            foreach (var pair in test)
            {
                Console.WriteLine(pair.Key);
            }
        }     
    }
