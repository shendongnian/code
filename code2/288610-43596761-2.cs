    public bool Update(IEnumerable<YourClass> yourClass)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            return conn.Insert(yourClass) ;
        }
    }
