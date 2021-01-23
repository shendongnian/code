      internal partial class DataModule
      {
        private DbProviderFactory DbProviderFactory { get; set; }
        private DbConnection DbConnection { get; set; }
    
        public DataModule()
        {
          var connectionStringSettings = ConfigurationManager.ConnectionStrings["Orion"];
          DbProviderFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
          DbConnection = DbProviderFactory.CreateConnection();
          DbConnection.ConnectionString = connectionStringSettings.ConnectionString;
        }
      }
