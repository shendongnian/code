    using (SqlCeConnection conn = new SqlCeConnection("connection string"))
    using (SqlCeCommand comm = new SqlCeCommand("DELETE FROM...", conn))
    {
        conn.Open();
        comm.ExecuteNonQuery();
    }
