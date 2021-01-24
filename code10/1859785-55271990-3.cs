    using System.Linq; 
    class Program
    {
        class Item
        {
            public int Key { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            var actions = new Dictionary<int, Action<Item>> {
                { 1, Action1 },
                { 2, Action2 },
                { 3, Action3 }
            };
            var items = new List<Item>();
            foreach (var group in items.GroupBy(x => x.Key))
            {
                var action = actions[group.Key];
                foreach (var item in group)
                {
                    action(item);
                }
            }
        }
        static void Action1(Item item)
        {
        }
        static void Action2(Item item)
        {
        }
        static void Action3(Item item)
        {
        }
    }
