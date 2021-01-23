    public delegate void ItemParentChangerDelegate(Item item, Item newParent);
    public class Item
    {
        public string Name{ get; set; }
        public Item Parent{ get; private set; }
        public ItemsCollection ChildItems;
        static Item()
        {
            // I hereby empower ItemsCollection to be able to set the Parent property:
            ItemsCollection.ItemParentChanger = (item, parent) => { item.Parent = parent };
            // Now I just have to trust the ItemsCollection not to do evil things with it, such as passing it to someone else...
        }
        public static void Dummy() { }
    
        public Item()
        {
            this.ChildItems = new ItemsCollection (this);
        }
    }
    
    public class ItemsCollection : ObservableCollection<Item>
    {
        static ItemsCollection()
        {
            /* Forces the static constructor of Item to run, so if anyone tries to set ItemParentChanger,
            it runs this static constructor, which in turn runs the static constructor of Item,
            which sets ItemParentChanger before the initial call can complete.*/
            Item.Dummy();
        }
        private static object itemParentChangerLock = new object();
        private static ItemParentChangerDelegate itemParentChanger;
        public static ItemParentChangerDelegate ItemParentChanger
        {
            private get
            {
                return itemParentChanger;
            }
            set
            {
                lock (itemParentChangerLock)
                {
                    if (itemParentChanger != null)
                    {
                        throw new InvalidStateException("ItemParentChanger has already been initialised!");
                    }
                    itemParentChanger = value;
                }
            }
        }
        public ItemsCollection(Item owner)
        {
            this.Owner = owner;
        }   
    
        public Item Owner{ get; private set; }
    
        private CheckParent(Item item)
        {
            if(item.Parent != null) throw new Exception("Item already belongs to another ItemsCollection");
            //item.Parent = this.Owner;
            ItemParentChanger(item, this.Owner); // Perfectly legal! :)
        }
    
        protected override void InsertItem(int index, Item item)
        {
            CheckParent(item);
            base.InsertItem(index, item);
        }
    
        protected override void RemoveItem(int index)
        {
            ItemParentChanger(this[index], null);
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, Item item)
        {
            var existingItem = this[index];
    
            if(item == existingItem) return;
    
            CheckParent(item);
            ItemParentChanger(existingItem, null);
    
            base.SetItem(index, item);
        }
    
        protected override void ClearItems()
        {
            foreach(var item in this) ItemParentChanger(item, null);
            base.ClearItems();
        }
