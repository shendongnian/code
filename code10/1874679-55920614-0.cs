    [CustomizedEnableQuery()]
    public IQueryable<Product> Get()
    {
        return _ProductRepository.GetAll();
    }
