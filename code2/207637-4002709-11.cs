    private DataTable Query(string sql)
    {
         var result = new DataTable();
         using (var connection = GetConnection())
         using (var command = new SqlCommand(sql, connection)
         {
             connection.Open();
             result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
         }
         return result;
    }
