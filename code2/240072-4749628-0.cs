    public IEnumerable<Product> GetProductsByName(string name)
    public IEnumerable<Product> GetProudctsByNameAndStock(string name, int stock)
    public IEnumerable<Product> GetProductsByNameAndReserved(
        string name,
        int reserved
    )
    public IEnumerable<Product> GetProducts(string name, int stock, int reserved)
