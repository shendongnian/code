    void DataTest()
    {
     using(SqlConnection conn1 = new SqlConnection(...)) {
      conn1.Open();
      SqlCommand mycommand = new SqlCommand("Select * From someTable", conn1);
      using(SqlDataReader myreader = mycommand.ExecuteReader()) {
       if(myreader != null)
        while(myreader.Read())
         Console.WriteLine(myreader.GetValue(0).ToString() + ":" + myreader.GetTypeName(0));
    
      }
      mycommand.Dispose(); 
     }
    }
