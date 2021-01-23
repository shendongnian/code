    public class Database
    {
        public static IDbConnection CreateOpenConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TheDatabase"];
            var providerName = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            connection.Open();
            return connection;
        }
    }
    class FlowerManager : DataWorker
    {
        public static void GetFlowers()
        {
            using (IDbConnection connection = Database.CreateOpenConnection())
            {
                using (IDbCommand command = connection.CreateCommand("SELECT * FROM FLOWERS", connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        // ...
                    }
                }
            }
        }
    }
