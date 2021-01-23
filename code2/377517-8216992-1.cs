    public class DataAccessLayer
    {
        private static DataAccessLayer me = new DataAccessLayer();
        private DataAccessLayer() { }
        public static DataAccessLayer GetInstance()
        {
            return me;
        }
        public Database GetDatabase(string connectionString, string provider)
        {
           DbProviderFactory providerFactory = DbProviderFactories.GetFactory(provider);
            return new GenericDatabase(connectionString,
                                       providerFactory);
        }
    }
    public class Repository
    {
        protected Database curDatabase;
        public Repository()
        {
            curDatabase = DataAccessLayer.GetInstance().GetDatabase("ConnectionString", "System.Data.Odbc");
        }
        public Database CurrentDatabase
        {
            get { return curDatabase; }
        }
    }
    public class UserRepository : Repository
    {
        public User GetUser(int urserID, int accountID)
        {
            using (IDataReader dataReader = CurrentDatabase.ExecuteReader("StroedProcName", urserID, accountID))
            {
                //User Details
                while (dataReader.Read())
                {
                    //Parse Data
                }
                dataReader.NextResult();
                //User Address(es)
                while (dataReader.Read())
                {
                    //Parse Data
                }
            }
        }
    }
