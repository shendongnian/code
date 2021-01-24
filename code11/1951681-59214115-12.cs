    protected async Task<IEnumerable<T>> QuerySqlCmdReadRows<T>(string sqlCommand)
    {
        using (var con = new SqlConnection(Connection.ToString()))
        {
            con.Open();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = sqlCommand;
                DataTable dtResult = new DataTable();
                using (var reader = await cmd.ExecuteReaderAsync())
                   dtResult.Load(reader);
                return dtResult.ToGenericList<T>();
            }
        }
    }
    // just and sample
    var students = QuerySqlCmdReadRows<Students>("select Id, Code, FirstName, LastName from Students");
