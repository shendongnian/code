    using (var conn = new SqlConnection(ConnectionStrings.toMyDB))
    {
        conn.Open();
        using (var cmd = new SqlCommand("myProc", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 30; // Increase this to allow the proc longer to run
            cmd.Parameters.AddWithValue("@Param", myParam);
            cmd.ExecuteNonQuery();
        }
    }
