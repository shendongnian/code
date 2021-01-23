    public DbConnection Connection
    {
        get
        {
            var objectContextAdapter = (IObjectContextAdapter) this;
            return objectContextAdapter.ObjectContext.Connection;
        }
    }
