    int PrimaryKey;
    using (OleDbConnection Connection = new OleDbConnection(CONNECTION_STRING))
    {
      Connection.Open();
    
      OleDbCommand Command = new OleDbCommand();
      Command.Connection = Connection;
      Command.CommandText = @"INSERT INTO Table1 
                              (JobNumber, ItemNumber) 
                              VALUES (@jobnumber, @itemnumber)";
    
      Command.Parameters.AddRange(new OleDbParameter[]
      {
        new OleDbParameter("@jobnumber", JobNumber),
        new OleDbParameter("@itemnumber", ItemNumber)
      });
      Command.ExecuteNonQuery();
      // Send the next command
      Command.Parameters.Clear();
      Command.CommandText = "SELECT @@IDENTITY";
      PrimaryKey = Convert.ToInt32(Command.ExecuteScalar());
    }
