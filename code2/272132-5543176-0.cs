    // open a new connection using a default connection string I have defined elsewhere
    using( OdbcConnection connection = new OdbcConnection( s_connectionString ) )
    {
          // ODBC command and transaction objects
          OdbcCommand command = new OdbcCommand();
          OdbcTransaction transaction = null;
    
          // tell the command to use our connection
          command.Connection = connection;
    
          try
          {
               // open the connection
               connection.Open();
    
               // start the transaction
               transaction = connection.BeginTransaction();
    
               // Assign transaction object for a pending local transaction.
               command.Connection = connection;
               command.Transaction = transaction;
    
               // TODO: Build a SQL INSERT statement
               StringBuilder SQL = new StringBuilder();
    
               // run the insert using a non query call
               command.CommandText = SQL.ToString();
               command.ExecuteNonQuery();
    
               /* now we want to make a second call to MYSQL to get the new index 
                  value it created for the primary key.  This is called using scalar so it will
                   return the value of the SQL  statement.  We convert that to an int for later use.*/
               command.CommandText = "select last_insert_id();";
               id = Convert.ToInt32( command.ExecuteScalar() );
    
               // Commit the transaction.
               transaction.Commit();
         }
         catch( Exception ex )
         {
              Debug.WriteLine( ex.Message );
    
              try
              {
                   // Attempt to roll back the transaction.
                   transaction.Rollback();
                }
                catch
                {
                     // Do nothing here; transaction is not active.
                  }
             }
    }
