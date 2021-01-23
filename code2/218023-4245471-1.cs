    public class ProductFetcher
    {
        // option 1: constructor injection
        private readonly IProductController _productController;
    
        public ProductFetcher(IProductController productController)
        {
            _productController = productController;
        }
        public Product FetchProductByID(int id)
        {
            return _productController.GetByID(id);
        }
    
        // option 2: inject it at the method level
        public static Product FetchProductByID(IProductController productController, int id)
        {
            return productController.GetByID(id);
        }
    
        // option 3: black box the whole thing, this is more of a servicelocator pattern
        public static Product FetchProductsByID(string controllerName, int id)
        {
            var productController = getProductController(controllerName);
            return productController.GetByID(id);
        }
    
        private static IProductController getProductController(string controllerName)
        {
            // hard code them or use configuration data or reflection
            // can also make this method non static and abstract to create an abstract factory
            switch(controllerName.ToLower())
            {
                case "someproductcontroller":
                    return new SomeProductController();
                case "anotherproductcontroller":
                    // etc
                    
                default:
                    throw new NotImplementedException();
            }
         }
    }
