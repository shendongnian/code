    public static double TestADONET_DataTable_TransferToAccess()
    {
      StringBuilder names = new StringBuilder();
      StringBuilder values = new StringBuilder();
      DataTable dt = new DataTable("TEMP");
      for (int k = 0; k < 20; k++)
      {
        string fieldName = "Field" + (k + 1).ToString();
        dt.Columns.Add(fieldName, typeof(int));
        if (k > 0)
        {
          names.Append(",");
          values.Append(",");
        }
        names.Append(fieldName);
        values.Append("@" + fieldName);
      }
      DateTime start = DateTime.Now;
      OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.AccessDB);
      conn.Open();
      OleDbCommand cmd = new OleDbCommand();
      cmd.Connection = conn;
      cmd.CommandText = "DELETE FROM TEMP";
      int numRowsDeleted = cmd.ExecuteNonQuery();
      Console.WriteLine("Deleted {0} rows from TEMP", numRowsDeleted);
      OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TEMP", conn);
      da.InsertCommand = new OleDbCommand("INSERT INTO TEMP (" + names.ToString() + ") VALUES (" + values.ToString() + ")");
      for (int k = 0; k < 20; k++)
      {
        string fieldName = "Field" + (k + 1).ToString();
        da.InsertCommand.Parameters.Add("@" + fieldName, OleDbType.Integer, 4, fieldName);
      }
      da.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
      da.InsertCommand.Connection = conn;
      //da.UpdateBatchSize = 0;
      for (int i = 0; i < 100000; i++)
      {
        DataRow dr = dt.NewRow();
        for (int k = 0; k < 20; k++)
        {
          dr["Field" + (k + 1).ToString()] = i + k;
        }
        dt.Rows.Add(dr);
      }
      da.Update(dt);
      conn.Close();
      double elapsedTimeInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
      Console.WriteLine("Append took {0} seconds", elapsedTimeInSeconds);
      return elapsedTimeInSeconds;
    }
