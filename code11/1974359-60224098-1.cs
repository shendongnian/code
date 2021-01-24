    using (var dbContext = new ProductsDbContext)
    {
        var draftedProducts = dbContext.Products
            .Where(product => product.Status == "draft)
            .ToList();
        dbContext.Products.RemoveRange(draftedProducts);
    }
