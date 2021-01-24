    // Constructor to use on a DbConnection that is already opened
    public MyDbContext(DbConnection existingConnection, bool contextOwnsConnection)
       : base(existingConnection, contextOwnsConnection)
    {
    }
