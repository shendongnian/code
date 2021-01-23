    using Newtonsoft.Json;
    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string json = File.ReadAllText("Test.json");
            Item item = JsonConvert.DeserializeObject<Item>(json);
            Console.WriteLine(item.References.Count); // Prints 1
            Console.WriteLine(item.Arts.Count);       // Prints 2
        }
    }
