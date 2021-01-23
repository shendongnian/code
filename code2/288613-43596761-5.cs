    public int Insert(YourClass yourClass)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            return conn.Insert(yourClass) ;
        }
    }
