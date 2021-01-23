    void RunStoredProc(string storedProcName, IDictionary<string, object> args)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> kvp in args)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
