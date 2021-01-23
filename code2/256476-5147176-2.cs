        public static IEnumerable<IDataRecord> SqlRetrieve(string ConnectionString, string StoredProcName,
                                                           Action<SqlCommand> addParameters)
        {
            using (var cn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(StoredProcName, cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                if (addParameters != null)
                {
                    addParameters(cmd);
                }
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        yield return rdr;
                }
            }
        }
