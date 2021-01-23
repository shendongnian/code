    public IQueryable<Product> GetProducts(int categoryID)
    {
        return from p in db.Products
               where p.CategoryID== categoryID
               select new { Name = p.Name}.ToList()
               .Select(x => new Product { Name = x.Name }).ToList();
    }
