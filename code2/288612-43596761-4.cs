    public int Insert(IEnumerable<YourClass> yourClass)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            return conn.Insert(yourClass) ;
        }
    }
