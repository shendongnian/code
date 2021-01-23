        public class ItemsCollection : ObservableCollection<IItem>
        {
            private class Item : IItem 
            {
                public object Parent { get; set; }
            }
            private CheckParent(IItem item)
            {
                if(item.Parent != null) throw new Exception("Item already belongs to another ItemsCollection");
                ((Item)item).Parent = this.Owner; // <-- This is where we need to access the private Parent setter
            }
    
            public static IItem CreateItem() { return new Item(); }
        }
    
        public interface IItem 
        {
            object Parent {get; }
        }
    
