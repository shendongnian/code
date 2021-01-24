    public class Resource : InventoryItem
    {
        public const int IDBase = 1000000;
    
        public static Resource Hydrogen { get; }
        public static Resource Helium { get; }
        public static Resource Lithium { get; }
        // ...
        private Resource(int id) : base(IDBase + id)
        {
        }
        private static Resource()
        {
            Hydrogen = new Resource(1);
            Helium = new Resource(2);
            Lithium = new Resource(3);
            // etc...
        }
    }
