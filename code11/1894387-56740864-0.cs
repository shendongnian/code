    public class SQLDataAccess
    {
        string cs = @"Server=172.20.10.5;Database=TestDB;Uid=Creative;Pwd=123456;";
        public SQLDataAccess()
        {
            try
            {
                connection = new MySqlConnection(cs);
                connection.Open();
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }
        private static SQLDataAccess _instance = null;
        public static SQLDataAccess Instance()
        {
            if (_instance == null)
                _instance = new SQLDataAccess();
            return _instance;
        }
        public bool IsConnect()
        {   
            try
            {
                connection = new MySqlConnection(cs);
                connection.Open();
                return true;
            }
            catch (MySqlException Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }
        }
        public void Close()
        {
            connection.Close();
        }
    }
 
