    public static double TestDAOTransferToAccess()
    {
      string databaseName = Properties.Settings.Default.AccessDB
        .Split(new char[] { ';' }).First(s => s.StartsWith("Data Source=")).Substring(12);
      DateTime start = DateTime.Now;
      DAO.DBEngine dbEngine = new DAO.DBEngine();
      DAO.Database db = dbEngine.OpenDatabase(databaseName);
      db.Execute("DELETE FROM TEMP");
      DAO.Recordset rs = db.OpenRecordset("TEMP");
      DAO.Field[] myFields = new DAO.Field[20];
      for (int k = 0; k < 20; k++) myFields[k] = rs.Fields["Field" + (k + 1).ToString()];
      //dbEngine.BeginTrans();
      for (int i = 0; i < 100000; i++)
      {
        rs.AddNew();
        for (int k = 0; k < 20; k++)
        {
          //rs.Fields[k].Value = i + k;
          myFields[k].Value = i + k;
          //rs.Fields["Field" + (k + 1).ToString()].Value = i + k;
        }
        rs.Update();
        //if (0 == i % 5000)
        //{
          //dbEngine.CommitTrans();
          //dbEngine.BeginTrans();
        //}
      }
      //dbEngine.CommitTrans();
      rs.Close();
      db.Close();
      double elapsedTimeInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
      Console.WriteLine("Append took {0} seconds", elapsedTimeInSeconds);
      return elapsedTimeInSeconds;
    }
