    public static double TestADONET_Insert_TransferToAccess()
    {
      StringBuilder names = new StringBuilder();
      for (int k = 0; k < 20; k++)
      {
        string fieldName = "Field" + (k + 1).ToString();
        if (k > 0)
        {
          names.Append(",");
        }
        names.Append(fieldName);
      }
      DateTime start = DateTime.Now;
      using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.AccessDB))
      {
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM TEMP";
        int numRowsDeleted = cmd.ExecuteNonQuery();
        Console.WriteLine("Deleted {0} rows from TEMP", numRowsDeleted);
        for (int i = 0; i < 100000; i++)
        {
          StringBuilder insertSQL = new StringBuilder("INSERT INTO TEMP (")
            .Append(names)
            .Append(") VALUES (");
          for (int k = 0; k < 19; k++)
          {
            insertSQL.Append(i + k).Append(",");
          }
          insertSQL.Append(i + 19).Append(")");
          cmd.CommandText = insertSQL.ToString();
          cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
      }
      double elapsedTimeInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
      Console.WriteLine("Append took {0} seconds", elapsedTimeInSeconds);
      return elapsedTimeInSeconds;
    }
