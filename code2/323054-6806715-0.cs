    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Item
    {
        // Don't make fields public normally!
        public readonly List<string> Keys = new List<string>();
        public string Name { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var groupingKeys = new List<string> { "Key1", "Key2" };
            var items = new List<Item>
            {
                new Item { Name="Object1", Keys = { "Key1" } },
                new Item { Name="Object2", Keys = { "Key2" } },
                new Item { Name="Object3", Keys = { "Key1", "Key2" } },
            };
            
            var query = from groupingKey in groupingKeys
                        from item in items
                        where item.Keys.Contains(groupingKey)
                        group item by groupingKey;
            
            foreach (var group in query)
            {
                Console.WriteLine("Key: {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("  {0}", item.Name);
                }
            }
        }
    }
