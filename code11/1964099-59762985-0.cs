    private readonly IAmbientDbContextLocator _contextLocator = new AmbientDbContextLocator();
    protected DbContext DbContext
    {
        get { return _contextLocator.Get<DbContext>(); }
    }
