    public class ConnectionFactory
    {
        public static MySqlConnection Create()
        {
            string connectionString = ConfigurationManager.AppSettings["..."];
            MySqlConnection conection = new MySqlConnection(Config.ConnectionStr);
            connection.Open();
            return connection;
        }
    }
