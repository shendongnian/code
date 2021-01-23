    string connectionStringWithMetadata = ConfigurationManager.ConnectionStrings["DbEntities"].ConnectionString;
    EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder(connectionStringWithMetadata);
    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(entityConnectionStringBuilder.ProviderConnectionString);
    // And now you can extract parts of the connection string
    string dbUserName = connectionStringBuilder.UserID; 
    string dbPassword = connectionStringBuilder.Password;
