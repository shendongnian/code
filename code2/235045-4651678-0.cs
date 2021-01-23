    static void DownloadBlob(OracleConnection myConnection)
    {
      OracleCommand myCommand = new OracleCommand("SELECT * FROM table", myConnection);
      myConnection.Open();
      OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
      try
      {
        while (myReader.Read())
        {
          //Obtain OracleLob directly from OracleDataReader
          OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("Ordinal"));
          if (!myLob.IsNull)
          {
            // I hope it is BLOB :)
          }
        }
      }
      finally
      {
        myReader.Close();
        myConnection.Close();
      }
    }
