    public async Task<IEnumerable< Products >> GetAllProducts()
     {
    var  products = _RepositoryContext.Set<Products> ();
    return await products.include(x =>x.ProductType).ToListAsync();
    
    }
