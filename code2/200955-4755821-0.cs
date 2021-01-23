    using (SQLiteTransaction mytransaction = myconnection.BeginTransaction())
    {
      using (SQLiteCommand mycommand = new SQLiteCommand(myconnection))
      {
        SQLiteParameter myparam = new SQLiteParameter();
        int n;
            
        mycommand.CommandText = "INSERT INTO [MyTable] ([MyId]) VALUES(?)";
        mycommand.Parameters.Add(myparam);
              
        for (n = 0; n < 100000; n ++)
        {
          myparam.Value = n + 1;
          mycommand.ExecuteNonQuery();
        }
      }
      mytransaction.Commit();
    }
