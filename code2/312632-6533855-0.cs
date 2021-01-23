    public IQueryable<Product> GetProduct(int id)
    {
        // Normal query, expression tree and sql generated each time it is
        // it is executed against the data source.
        return context.Products.Where(p => p.Id == id);
    }
