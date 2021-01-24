    SQLiteConnection connection = new SQLiteConnection("Data Source=filepath;Version=3");
    sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='{table_name}';"
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    try 
    {
      var result = command.ExecuteReader();
      if (result.HasRows) 
      {
        // INSERT statement here
      }
    }
    catch (Exception e) 
    {
      throw e;
    }
    
