    ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[name];  
  
    if (c == null)
    {
        ... handle missing connection string ...
    }
    string fixedConnectionString = c.ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
    ... use fixedConnectionString
