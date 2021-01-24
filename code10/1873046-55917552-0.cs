    private readonly DatabaseSettings _databaseOptions;
    public ApplicationDbContext() { }
    public ApplicationDbContext(IOptions<DatabaseSettings> databaseOptions)
    {            
        _databaseOptions = databaseOptions.Value;
    }
