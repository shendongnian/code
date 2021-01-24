    class MyDb : DbContext
    {
    
        public SqlConnection GetConnection()
        {
            var con = (SqlConnection)Database.Connection;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
    }
