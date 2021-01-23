    string providerName = ConfigurationManager.ConnectionStrings["myconnectionname"].ProviderName;
    DbProviderFactory provider =
        DbProviderFactories.GetFactory(providerName);
    
    IDbConnection conn = provider.CreateConnection();
    IDbCommand command = provider.CreateCommand();
