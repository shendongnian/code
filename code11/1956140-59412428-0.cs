    On_Cancel_Button_Click()
    {
      using (var con = new OracleConnection(...))
      {
         using (var tran = con.BeginTransaction())
         {
            Cancel(con);
            Confirm(con);
    
            tran.Commit();
         }
      }
