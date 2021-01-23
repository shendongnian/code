    public void RunAsTransaction(string myConnString) 
    {
    SqlConnection myConnection = new SqlConnection(myConnString);
    myConnection.Open();
    SqlCommand myCommand = myConnection.CreateCommand();
    SqlTransaction myTrans;
    
    myTrans = myConnection.BeginTransaction();
    myCommand.Connection = myConnection;
    myCommand.Transaction = myTrans;
    try
    {
      myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
      myCommand.ExecuteNonQuery();
      myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
      myCommand.ExecuteNonQuery();
      myTrans.Commit();
      }
    catch(Exception e)
    {
      myTrans.Rollback();
    }  
    finally 
    {
      myConnection.Close();
    }
   }
