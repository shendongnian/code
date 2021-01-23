    string sqlLiteConnectionString = "your_connection_string";
    var entityConnectionString = new EntityConnectionStringBuilder
    {
      Metadata = "res://*",
      Provider = "System.Data.SqlClient",
      ProviderConnectionString = sqlLiteConnectionString,
    }.ConnectionString;
    var entities = new dataEntities(entityConnectionString);
