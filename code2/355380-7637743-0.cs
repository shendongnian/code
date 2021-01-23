    static public IEnumerable<IDataRecord> GetDataReader(string sql, SqlParameter[] parms)
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.CommandTimeout = 120; //120 seconds for the query to finish executing
            foreach (SqlParameter p in parms)
            {
                cmd.Parameters.Add(p);
            }
            conn.Open();
            using (var dr= cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    yield return dr;
                }
            }
        }
    }
   
