    using System;
    using System.Collections.Generic;
    class MainClass {
        static private protected Dictionary<string, int> pizzaCost = new Dictionary<string, int>() 
        {
              { "Sample-A", 1 },
              { "Sample-B", 2 },
              { "Sample-C", 3 }
        };
        static void Main (string[] args) {
            Console.WriteLine("Pizza Total: {0}", pizzaCost["Sample-A"] + pizzaCost["Sample-B"] + pizzaCost["Sample-C"]);
            Console.ReadKey();
        }
    }
