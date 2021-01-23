    public List<Product> GetProducts(int categoryID)
    {
        var query = from p in db.Products
                where p.CategoryID == categoryID
                select new { Name = p.Name };
        var products = query.ToList().Select(r => new Product
        {
            Name = r.Name;
        }).ToList();
    
        return products;
    }
