    public static double TestTextTransferToAccess()
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
      StreamWriter sw = new StreamWriter(Properties.Settings.Default.TEMPPathLocation);
      sw.WriteLine(names);
      for (int i = 0; i < 100000; i++)
      {
        for (int k = 0; k < 19; k++)
        {
          sw.Write(i + k);
          sw.Write(",");
        }
        sw.WriteLine(i + 19);
      }
      sw.Close();
      ACCESS.Application accApplication = new ACCESS.Application();
      string databaseName = Properties.Settings.Default.AccessDB
        .Split(new char[] { ';' }).First(s => s.StartsWith("Data Source=")).Substring(12);
      accApplication.OpenCurrentDatabase(databaseName, false, "");
      accApplication.DoCmd.RunSQL("DELETE FROM TEMP");
      accApplication.DoCmd.TransferText(TransferType: ACCESS.AcTextTransferType.acImportDelim,
      TableName: "TEMP",
      FileName: Properties.Settings.Default.TEMPPathLocation,
      HasFieldNames: true);
      accApplication.CloseCurrentDatabase();
      accApplication.Quit();
      accApplication = null;
      double elapsedTimeInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
      Console.WriteLine("Append took {0} seconds", elapsedTimeInSeconds);
      return elapsedTimeInSeconds;
    }
