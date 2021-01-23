    public class Item
    {
        public string Family { get; set; }
        public int Value { get; set; }
    }
    foreach (Item item in _List
            .AsQueryable()._GroupMaxs<Item, String, int>("Family", "Value"))
        Console.WriteLine("{0}:{1}", item.Family, item.Value);
