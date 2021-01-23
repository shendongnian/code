    private static IEnumerable<IDataRecord> SqlRetrieve(string ConnectionString, string StoredProcName,
                                                               Action<SqlCommand> AddParameters)
            {
                using (var cn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(StoredProcName, cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    if (AddParameters != null)
                    {
                        AddParameters(cmd);
                    }
    
                    using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (rdr.Read())
                            yield return rdr;
                    }
                }
            }
