    public DataTable Read1<T>(string query) where T : IDbConnection, new()
    {
        using (var conn = new T())
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Connection.ConnectionString = _connectionString;
                cmd.Connection.Open();
                var table = new DataTable();
                table.Load(cmd.ExecuteReader());
                return table;
            }
        }
    }
    public DataTable Read2<S, T>(string query) where S : IDbConnection, new() 
                                               where T : IDbDataAdapter, IDisposable, new()
    {
        using (var conn = new S())
        {
            using (var da = new T())
            {
                using (da.SelectCommand = conn.CreateCommand())
                {
                    da.SelectCommand.CommandText = query;
                    da.SelectCommand.Connection.ConnectionString = _connectionString;
                    DataSet ds = new DataSet(); //conn is opened by dataadapter
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
    }
