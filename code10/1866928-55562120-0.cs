        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlConnBuilder = new SqlConnectionStringBuilder();
            sqlConnBuilder.DataSource = Environment.MachineName;
            sqlConnBuilder.UserID = Environment.MachineName + "\\userName";
            sqlConnBuilder.InitialCatalog = "dataBaseName";
            sqlConnBuilder.IntegratedSecurity = true;
            SqlConnection conn = new SqlConnection(sqlConnBuilder.ConnectionString);
            return conn;
        }
