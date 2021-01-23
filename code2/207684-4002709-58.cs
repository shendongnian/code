    private DataTable Query(string sql, Action<SqlParameterCollection> addParameters)
    {
        var result = new DataTable();
        using (var connection = GetConnection())
        using (var command = new SqlCommand(sql, connection)
        {
            //addParameters is a function we can call that was as an argument
            addParameters(command.Parameters);
            connection.Open(); 
            result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
        }
        return result;
    }
