    public PageResult<Product> Get(ODataQueryOptions<ProductDTO> options)
    {
        ODataQuerySettings settings = new ODataQuerySettings()
        {
            PageSize = 5
        };
        IQueryable results = options.ApplyTo(_products.AsQueryable().ProjectTo<ProductDTO>(), settings);
        return new PageResult<Product>(
            results as IEnumerable<Product>, 
            Request.GetNextPageLink(), 
            Request.GetInlineCount());
    }
