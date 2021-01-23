        using (var conn = new SqlConnection("connection string"))
        using (var comm = new SqlCommand("", conn))
        {
            conn.Open();
    #if DEBUG
            comm.CommandText = "WAITFOR DELAY '00:00:01.000'; SELECT * FROM MyTable";
    #else
            comm.CommandText = "SELECT * FROM MyTable";
    #endif
            comm.ExecuteNonQuery();
        }
