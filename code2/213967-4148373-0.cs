    function DoWork() {
      using (TransactionScope scope = new TransactionScope(...)) {
        cmd = new SqlCommand("select ...");
        using (DataReader rdr = cmd.ExecuteReader ()) {
            while(rdr.Read()) {
              ... process each record
            }
        }
        scope.Complete ();
      }
    }
