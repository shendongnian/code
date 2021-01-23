    string[] tables = new string[] { "TableA", "TableB", "TableC" ... };
    var runningCommands = new List<SqlCommand>();
    foreach(var table in tables)
    {
      var conn = new SqlConnection(...);
      conn.Open();
      var cmd = new SqlCommand("DELETE FROM " + table + " WHERE id = @id");
      cmd.Parameters.Add(new SqlParameter("@id", id);
      cmd.BeginExecuteNonQuery(); 
      runningCommands.Add(cmd);
    }
    // now wait for all of them to finish executing
    foreach(var cmd in runningCommands)
    {
      cmd.EndExecuteNonQuery();
      cmd.Connection.Close();
    }
