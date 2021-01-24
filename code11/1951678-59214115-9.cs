    protected async Task<IEnumerable<T>> QuerySqlCmdReadRows<T>(string sqlCommand)
    {
        using (var con = new SqlConnection(Connection.ToString()))
        {
            con.Open();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandTimeout = int.MaxValue;
                cmd.CommandText = sqlCommand;
                var reader = await cmd.ExecuteReaderAsync();
                DataTable tbl = new DataTable();
                tbl.Load(reader);
                return tbl.ToGenericList<T>();
            }
        }
    }
    // just and sample
    var students = QuerySqlCmdReadRows<Students>("select Id, Code, FirstName, LastName from Students");
