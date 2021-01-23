    private static IEnumerable<IDataRecord> Retrieve(string sql, Action<SqlParameterCollection> addParameters)
    {
        using (var cn = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(sql, cn))
        {
            addParameters(cmd.Parameters);
    
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                    yield return rdr;
                rdr.Close();
            }
        }
    }
