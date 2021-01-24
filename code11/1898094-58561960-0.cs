    namespace SharedTools
    {
        public class AzureDBConfiguration : DbConfiguration
        {
            public AzureDBConfiguration()
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            }
        }
    }
