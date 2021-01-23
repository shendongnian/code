    var originalConnectionString = ConfigurationManager.ConnectionStrings["your_connection_string"].ConnectionString;
    var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
    var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
    var providerBuilder = factory.CreateConnectionStringBuilder();
    providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
    providerBuilder.Add("Password", "Password123");
    entityBuilder.ProviderConnectionString = providerBuilder.ToString();
    using (var context = new YourContext(entityBuilder.ToString()))
    {
        // TODO
    }
