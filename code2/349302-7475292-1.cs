     protected void SqlExecute(Action a)
     {
       if (sqlConnection.State != ConnectionState.Connected)
         sqlConnection.Open();
       a();
     }
