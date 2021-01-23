    IEnumerable<Product> GetProducts(params Func<Product, bool>[] criteria)
    {
        var query = Products.Where(p => p.CategoryID == 125);
        foreach(criterion in criteria)
        {
            query = query.Where(criterion);
        }
        return query;
    }
    // ...
    var notFiltered = someObject.GetProducts().ToList();
    var filtered = someObject
        .GetProducts(
            p => p.Price > 25,
            p => p.AverageReviewScore > 4
            )
        .ToList();
