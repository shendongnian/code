    static class DbExtensions{
       public IQueryable<Product> ProductsWithCategories(this MyContext db) {
           return db.Products.Include("Category");
       }
    }
