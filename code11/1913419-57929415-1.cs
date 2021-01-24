    [DbConfigurationType(typeof(MyCustomSQLDbConfiguration))]
    public class MySqlDBContext : DbContext
    {
        public MySqlDBContext() : base("MySqlDBContext")
        {
        }
     }
