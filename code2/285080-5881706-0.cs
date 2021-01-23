    class ProductRepository : IProductRepository, IDisposable
    {
        var context;
        public ProductRepository() {
            this.context = new MyDataBaseDataContext(); 
        }
        // the rest of methods
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
