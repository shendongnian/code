        public static IEnumerable<IDataRecord> SqlRetrieve(string ConnectionString, string StoredProcName, Action<SqlCommand> addParameters)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(StoredProcName, cn))
            {
                cn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (addParameters != null)
                {
                    addParameters(cmd);
                }
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        yield return rdr;
                }
            }
        }
