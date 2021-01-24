    public class AllData
    {
        public Item[] Data { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public IDictionary<string, object> Values { get; set; }
    }
