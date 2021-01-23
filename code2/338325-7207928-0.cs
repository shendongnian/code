    // create the table
    string commandString  = "CREATE TABLE ...";
    // run the command in a transaction and commit it
    mtransaction = Connection.BeginTransaction( IsolationLevel.Serializable );
    FbCommand command = new FbCommand(commandString, Connection, mtransaction);
    command.ExecuteNonQuery();
    transaction.Commit();
    transaction.Dispose();
    transaction = null;
    // copy the data to the new table from the old
    commandString = "INSERT INTO ...";
    mtransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
    FbCommand command = new FbCommand(commandString, Connection, mtransaction);
    command.ExecuteNonQuery();
    transaction.Commit();
    transaction.Dispose();
    transaction = null;
    // ------------------  
    // Drop the connection entirely and start a new one
    // so the table can be dropped 
    Connection.Close();
    Connection.Dispose();
    // build connection string 
    FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
    csb.DataSource ... etc...
    // connect
    Connection = new FbConnection(connectionString);
    Connection.Open();
    // Now have new connection that does not have weird
    // lingering query, and table can now be dropped
    // -----------------
  
    // drop the old table
    commandString = "DROP TABLE ...";
    mtransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
    FbCommand command = new FbCommand(commandString, Connection, mtransaction);
    command.ExecuteNonQuery();
    // this no longer fails because the connection was complete closed
    // and re-opened
    transaction.Commit();
    transaction.Dispose();
    transaction = null;
