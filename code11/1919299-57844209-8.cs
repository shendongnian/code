    // Member of IAuditInspectionDataService 
    public void GetCheckList(CancellationToken cancellationToken, string connectionString, string queryString)
    { 
      using (OleDbConnection connection = new OleDbConnection(connectionString))
      {
        OleDbCommand command = new OleDbCommand(queryString, connection);
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
