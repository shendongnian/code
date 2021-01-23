    public static IDbConnection connect(String connectionString)
    {
        if ( dbtype == "mysql" )
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        else if ( dbtype == "mssql" )
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
