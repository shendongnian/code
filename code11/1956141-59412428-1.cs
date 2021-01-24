    void CancelAndConfirmTicket()
    {
      using (var con = new OracleConnection(...))
      {
         con.Open();
         using (var tran = con.BeginTransaction())
         {
            Cancel(con);
            Confirm(con);
    
            tran.Commit();
         }
      }
