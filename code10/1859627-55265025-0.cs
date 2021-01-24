    private readonly FICTIEContext _Database;
    public LoginDAL()
    {
        _Database = new FICTIEContext();
    }
    public LoginDAL(FICTIEContext database)
    {
        _Database = database;
    }
