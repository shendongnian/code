    public void RunOracleTransaction(string myConnString)
    {
       OracleConnection myConnection = new OracleConnection(myConnString);
       myConnection.Open();
    
       OracleCommand myCommand = myConnection.CreateCommand();
       OracleTransaction myTrans;
    
       // Start a local transaction
       myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
       // Assign transaction object for a pending local transaction
       myCommand.Transaction = myTrans;
    
       try
       {
     myCommand.CommandText = "INSERT INTO Dept (DeptNo, Dname, Loc) values (50,     'TECHNOLOGY', 'DENVER')";
         myCommand.ExecuteNonQuery();
     myCommand.CommandText = "INSERT INTO Dept (DeptNo, Dname, Loc) values (60,     'ENGINEERING', 'KANSAS CITY')";
         myCommand.ExecuteNonQuery();
         myTrans.Commit();
         Console.WriteLine("Both records are written to database.");
       }
       catch(Exception e)
       {
         myTrans.Rollback();
         Console.WriteLine(e.ToString());
         Console.WriteLine("Neither record was written to database.");
       }
       finally
       {
         myConnection.Close();
       }
    }
