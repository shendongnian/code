    public class Item
    {
        public string Name{ get; set; }
        public Item Parent{ get; internal set; } // changed to internal...
        public ItemsCollection ChildItems;
    
        public Item()
        {
            this.ChildItems = new ItemsCollection (this);
        }
    }
