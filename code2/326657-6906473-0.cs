    public class ConnectionFactory
    {
        public static Create()
        {
            string connectionString = ConfigurationManager.AppSettings["..."];
            MySqlConnection conection = new MySqlConnection(Config.ConnectionStr);
            connection.Open();
            return connection;
        }
    }
