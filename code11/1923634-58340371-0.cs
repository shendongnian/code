    class DBConnect
    {
        private MySqlConnection connection;
        private string datasource;
        private string username;
        private string password;
        private string database;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        //Initialize values
        public void Initialize()
        {
            datasource = "127.0.0.1";
            username = "username";
            password = "password";
            database = "database_name";
            string connectionString = "datasource=" + datasource + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database + ";";
            connection = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Test Connection to the Server
        /// </summary>
        private void DBConnection()
        {
            //string ConnectionString = "datasource = localhost; username = root; password = ; database = test ";
            MySqlConnection DBConnect = new MySqlConnection(ConnectionString);
            try
            {
                DBConnect.Open();
                System.Windows.Forms.MessageBox.Show("Sucessfully connected!");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
