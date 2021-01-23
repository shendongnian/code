    public sealed class ItemsCollection : ObservableCollection<Item>
    {
        private Dictionary<Item, Guid> guids = new Dictionary<Item, Guid>();
        public ItemsCollection(Item owner)
        {
            this.Owner = owner;
        }
        public Item Owner { get; private set; }
        
        private Guid CheckParent(Item item)
        {
            if (item.Parent != null)
                throw new Exception("Item already belongs to another ItemsCollection");
            //item.Parent = this.Owner; // <-- This is where we need to access the private Parent setter     
            return item.BecomeMemberOf(this);
            
        }
        
        protected override void InsertItem(int index, Item item)
        {
            Guid g = CheckParent(item);
            base.InsertItem(index, item);
            guids.Add(item, g);
        }
        
        protected override void RemoveItem(int index)
        {
            Item item = this[index];
            DisownItem(item);
            base.RemoveItem(index);
        }
        protected override void DisownItem(Item item)
        {
            item.BecomeOrphan(guids[item]);
            guids.Remove(item);            
        }
        protected override void SetItem(int index, Item item)
        {
            var existingItem = this[index];
            if (item == existingItem)
                return;
            Guid g = CheckParent(item);
            existingItem.BecomeOrphan(guids[existingItem]);
            base.SetItem(index, item);
            guids.Add(item, g);
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
                DisownItem(item);
            base.ClearItems();
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public Item Parent { get; private set; }
        
        public ItemsCollection ChildItems;
        
        public Item()
        {
            this.ChildItems = new ItemsCollection(this);
        }
        
        private Guid guid;
        
        public Guid BecomeMemberOf(ItemsCollection collection)
        {
            if (Parent != null)
                throw new Exception("Item already belongs to another ItemsCollection");
            Parent = collection.Owner;
            guid = new Guid();
            return guid; // collection stores this privately         
        }
        public void BecomeOrphan(Guid guid) // collection passes back stored guid         
        {
            if (guid != this.guid)
                throw new InvalidOperationException("Item can only be orphaned by its current collection");
            Parent = null;
        }
    }
