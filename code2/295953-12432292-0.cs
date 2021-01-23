    public MyDataContext() : 
      base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString, mappingSource)
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<Person>(o => o.Addresses);
        this.LoadOptions = options;
        OnCreated();
    }
