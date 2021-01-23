    public MyDataContext() : 
      base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString, mappingSource)
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<Customer>(o => o.City);
        this.LoadOptions = options;
        OnCreated();
    }
