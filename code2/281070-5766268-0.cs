    private static List<Products> GetProducts<TOrderBy>(Expression<Func<Products, bool>> filter,
                   Expression<Func<Products, TOrderBy>> orderBy, Table<Products> Products)
    {
    
        var products = Products.Where(filter).OrderBy(orderBy);
        return products.ToList();
    }
