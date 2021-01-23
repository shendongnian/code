    private DataTable Query(string sql, Action<SqlCommand> addParameters)
    {
         var result = new DataTable();
         using (var connection = GetConnection())
         using (var command = new SqlCommand(sql, connection)
         {
             addParameters(command); //<--- the addParameters parameter is a function we can call
             connection.Open(); 
             result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
         }
         return result;
    }
