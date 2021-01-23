    public class ProductRepository : IProductRepository
      {    
        private Table<Product> productTable;    
        
        public Product GetProductById(int id)    {         
            return GetProducts().Where(p => p.ProductId == id).Single();    
        }    
    
        public IQueryable<Product> GetProducts()    {        
          return productTable;    
        } 
    }
