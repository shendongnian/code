    using (var conn = new SqlConnection("connection string"))
    using (var comm = new SqlCommand("", conn))
    {
        conn.Open();
        comm.CommandText = "SELECT * FROM MyTable";
        comm.ExecuteNonQuery();
    }
