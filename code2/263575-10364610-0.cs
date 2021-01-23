    public class PseudoProduct : Product { }
    public IQueryable<Product> GetProducts(int categoryID)
    {
        return from p in db.Products
               where p.CategoryID== categoryID
               select new PseudoProduct() { Name = p.Name};
    }
