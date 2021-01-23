    class Product {}
    
    [MapTo("<GUID>"]  //your attribute...
    class SpecialA : Product { }
    
    class ProductFactory
    {
        private Dictionary<Guid, Type> _productMap = ...;
        
        public ProductFactory() 
        {
            //Initialize map to types that are Products AND have a MapTo attribute
        }
    
        public Product[] GetBy(...criteria...) 
        {
            // dynamically instantiate Products
            // if the Guid exists in map, use that type
            // otherwise, use Product
        }
    }
