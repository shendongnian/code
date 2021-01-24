    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace SO59038883
    {
        internal class Program
        {
            static void Main()
            {
                // keep track of the key that have been inserted
                // so we can remove a random
                var trackedKeys = new List<int>();
    
                var rand = new Random();
                var map = new Dictionary<int, int>();
                for (var i = 0; i < 20; i++)
                {
                    var key = rand.Next(1000000000);
                    trackedKeys.Add(key);
                    Console.WriteLine($"Key: {key}");
    
                    if (map.ContainsKey(key))
                        continue;
    
                    map.Add(key, i);
    
                    // Let's remove three random keys
                    // at set interval
                    if (i == 5 || i == 10 || i == 15)
                    {
                        // get a random key from our tracked key list
                        var index = rand.Next(trackedKeys.Count);
                        var keyToRemove = trackedKeys[index];
                        map.Remove(keyToRemove);
                    }
                }
    
                Console.WriteLine("Reading Back..");
                foreach (var pair in map)
                {
                    Console.WriteLine($"Key: {pair.Key} - Value: {pair.Value}");
                }
    
                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
