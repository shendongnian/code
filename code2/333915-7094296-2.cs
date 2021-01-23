    public class DbHelper 
    {
        public static DbConnection GetOpenConnection()
        {
            var db = DatabaseFactory.CreateDatabase("MyDatabase");
            var cnn = db.CreateConnection();
            cnn.ConnectionString = "Data Source=localh;Initial Catalog=DatabaseTest;User ID=sa;Password=Password";
            return MvcMiniProfiler.Data.ProfiledDbConnection.Get(cnn, MvcMiniProfiler.MiniProfiler.Current);
        }
    }
