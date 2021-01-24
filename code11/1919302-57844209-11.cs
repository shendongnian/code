    // Member of IAuditInspectionDataService 
    public void GetCheckList(CancellationToken cancellationToken)
    { 
      using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"myfile.xls\";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\""))
      {
        OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
        connection.Open();
        OleDbDataReader reader = command.ExecuteReader();
   
        int partitionSize = 50;
        int linesRead = 0;
        while (reader.Read())
        {
          if (++linesRead == partitionSize)
          {
            cancellationToken.ThrowIfCancellationRequested();
            llnesRead = 0;
          }
          Console.WriteLine(reader[0].ToString());
        }
        reader.Close();
      }  
    }
