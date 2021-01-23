     protected void SqlExcevute(Action a)
     {
       if (sqlConnection.State != ConnectionState.Connected)
         sqlConnection.Open();
       a();
     }
