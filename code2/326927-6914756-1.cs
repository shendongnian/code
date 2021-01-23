    string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
    string sqlLiteConnectionString = string.Format(
      "data source=\"{0}\";datetimeformat=Ticks", 
      Path.Combine(baseFolder, "data.db3"));
    var entityConnectionString = new EntityConnectionStringBuilder
    {
      Metadata = "res://*",
      Provider = "System.Data.EntityClient",
      ProviderConnectionString = sqlLiteConnectionString,
    }.ConnectionString;
    var entities = new dataEntities(entityConnectionString);
