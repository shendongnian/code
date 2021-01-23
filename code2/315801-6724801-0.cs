    public delegate void ItemParentChangerDelegate(Item item, Item newParent);
    public class Item
    {
        public string Name{ get; set; }
        public Item Parent{ get; private set; }
        public ItemsCollection ChildItems;
    
        public Item()
        {
            // I hereby empower this ItemsCollection to be able to set my Parent property:
            this.ChildItems = new ItemsCollection (this, (item, parent) => { item.Parent = parent });
            // Now I just have to trust the ItemsCollection not to do evil things with it, such as passing it to someone else...
        }
    }
    
    public class ItemsCollection : ObservableCollection<Item>
    {
        private ItemParentChangerDelegate itemParentChanger;
        public ItemsCollection(Item owner, ItemParentChangerDelegate itemParentChanger)
        {
            this.Owner = owner;
            this.itemParentChanger = itemParentChanger;
        }   
    
        public Item Owner{ get; private set; }
    
        private CheckParent(Item item)
        {
            if(item.Parent != null) throw new Exception("Item already belongs to another ItemsCollection");
            //item.Parent = this.Owner;
            itemParentChanger(item, this.Owner); // Perfectly legal! :)
        }
    
        protected override void InsertItem(int index, Item item)
        {
            CheckParent(item);
            base.InsertItem(index, item);
        }
    
        protected override void RemoveItem(int index)
        {
            itemParentChanger(this[index], null);
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, Item item)
        {
            var existingItem = this[index];
    
            if(item == existingItem) return;
    
            CheckParent(item);
            itemParentChanger(existingItem, null);
    
            base.SetItem(index, item);
        }
    
        protected override void ClearItems()
        {
            foreach(var item in this) itemParentChanger(item, null);
            base.ClearItems();
        }    
