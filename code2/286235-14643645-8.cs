        public static Database CreateDatabase(string ConnectionString)
        {
            //var Conn = ConfigurationManager.ConnectionStrings[ConnectionString].ToString();
            if (string.IsNullOrEmpty(ConnectionString))
                throw new Exception("Connectionstring Not Found" + ConnectionString);
            Database db = null;
            if (ConfigurationManager.ConnectionStrings[ConnectionString].ProviderName.Contains("Oracle"))
            {
                db = new OracleDatabase();
                db.ConnectionString = GetConnectionString(ConnectionString);
                db.Connection = db.CreateConnection();
            }
            else
            {
                db = new SQLDatabase();
                db.ConnectionString = GetConnectionString(ConnectionString);
                db.Connection = db.CreateConnection();
            }
            return db;
        }
