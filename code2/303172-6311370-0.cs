    public class Item
    {
        public Item(string name) { Name = name; }
        public string Name { get; set; }
        public Item Self { get { return this; } }
    }
