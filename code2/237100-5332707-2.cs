    public MyDataContext()
    {
        this.Connection.Open();
    }
    protected override void Dispose(bool disposing)
    {
        if (this.Connection.State == ConnectionState.Open)
            this.Connection.Close();
        base.Dispose(disposing);
    }
    private DbConnection Connection
    {
        get
        {
            var objectContextAdapter = (IObjectContextAdapter) this;
            return objectContextAdapter.ObjectContext.Connection;
        }
    }
