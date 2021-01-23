      DbProviderFactory providerFactory = 
          DbProviderFactories.GetFactory("Oracle.DataAccess.Client");
      Database dbServer = 
          new Microsoft.Practices.EnterpriseLibrary.Data
                                 .GenericDatabase("connection string", providerFactory);
