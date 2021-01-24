    [DbConfigurationType(typeof(DBContextConfig))]
    partial class 
    {
    
        public Entities(string connectionString)
          : base(connectionString)
        {
        }
    }
    
    public class DBContextConfig : DbConfiguration
    {
        public DBContextConfig()
        {
            SetProviderServices("System.Data.EntityClient", SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlConnectionFactory());
        }
    }
