    public Object[] Get(ODataQueryOptions<ProductDTO> options)
    {
        ODataQuerySettings settings = new ODataQuerySettings()
        {
            PageSize = 5
        };
        IQueryable results = options.ApplyTo(_products.AsQueryable().ProjectTo<ProductDTO>(), settings);
        results.ToArray()
    }
