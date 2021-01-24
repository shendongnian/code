    public static List<Product> GetProducts(List<int> ids)
    {
        return Orders.
            SelectMany(
            o => o.Products
            .Where(p => ids.Any(id => id == p.Id)))
            .ToList();
    }
