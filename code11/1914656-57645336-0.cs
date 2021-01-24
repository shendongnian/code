    public IQueryable<(string, int)> Results { get; set; } // I suppose ProductName is string and Cost is int
    public void Store()
    {
        Results = db.Products.Select(x => (x.ProductName, x.Cost));
    }
