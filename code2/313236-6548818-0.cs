        internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
    class ProductRepositoryCustumerOne : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            //code to retrieve data
        }
    }
    class ProductRepositoryCustumerTwo : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            //code to retrieve data
        }
    }
