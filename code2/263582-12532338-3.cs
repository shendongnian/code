    public IEnumerable<Product> GetProducts(int categoryID)
    {
        return (from p in Context.Set<Product>()
                where p.CategoryID == categoryID
                select new { Name = p.Name }).ToList()
               .Select(x => new Product { Name = x.Name });
    }
