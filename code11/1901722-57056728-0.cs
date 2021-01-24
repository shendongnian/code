    public class Item
    {
        public string Id { get; private set; }
    
        public string ParentId {get; set;}
        public Item Parent { get; set; }
    
        public List<Item> Children { get; private set; }
    }
