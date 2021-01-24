    public class MyCustomSQLDbConfiguration : DbConfiguration
    {
        public MyCustomSQLDbConfiguration()
        {
            SetExecutionStrategy("MySql.Data.MySqlClient", () => new MySqlExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
        }
    }
