    using System.Data.SqlClient;
    private void DoSomething(string storedProcedure, string tableName)
    {
     using (var conn = new SqlConnection(ConnectionString))
     {
      conn.Open();
      var cmd = new SqlCommand(storedProcedure, conn) { CommandType = CommandType.StoredProcedure };
      cmd.Parameters.Add(new SqlParameter("@tablename", SqlDbType.NVarChar, 80));
      cmd.Parameters["@tablename"].Value = tableName;
      cmd.ExecuteNonQuery();
     }
    }
