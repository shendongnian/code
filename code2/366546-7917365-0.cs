     using (OleDbConnection connection = new OleDbConnection(connstr))
     {
         connection.Open();
         using (OleDbCommand commands = connection.CreateCommand())
         {
             //snip
         }
     }
