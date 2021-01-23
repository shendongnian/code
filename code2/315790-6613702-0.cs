    public class ItemsCollection
    {
        private class Item : IItem 
        {
            public object Parent { get; set; }
        }
        
        public static IItem CreateItem() { return new Item(); }
    }
    
    public interface IItem 
    {
        object Parent {get; }
    }
    
