    ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[name];
    DbProviderFactory factory = DbProviderFactories.GetFactory(c.ProviderName);
    using(IDbConection connection = factory.CreateConnection())
    {
        connection.ConnectionString = c.ConnectionString;
        ... etc
    }
