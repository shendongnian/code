    private readonly DBModelContext _DbContext; //Try removing static
    public Program(DBModelContext dbContext)
    {
        _DbContext = dbContext;
    }
