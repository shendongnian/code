    var root = JsonConvert.DeserializeObject<RootObject[]>(inputString);
    public class RootObject
    {
        public int id { get; set; }
        public string model { get; set; }
        public Item fields { get; set; }
    }
    public class Item
    {
        public string name { get; set; }
        public int slot { get; set; }
        public string category { get; set; }
    }
