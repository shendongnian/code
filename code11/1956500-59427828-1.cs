    var settings = ConfigurationManager.ConnectionStrings[connectionStringName];
    var factory = DbProviderFactories.GetFactory(settings.ProviderName);
    using (var conn = factory.CreateConnection())
    using (var cmd = conn.CreateCommand())
    {
      conn.ConnectionString = settings.ConnectionString;
      conn.Open();
      ...
      conn.Close();
    }
