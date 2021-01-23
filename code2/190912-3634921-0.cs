    SqlConnection sqlConnection = new SqlConnection( "connstring" );
    sqlConnection.Open();
    
    // open transaction
    SqlTransaction transaction = sqlConnection.BeginTransaction();
    
    string temp = string.Format( "CREATE TABLE dbo.#temp (id INT);" );
    DbCommand command = database.GetSqlStringCommand( temp );
    database.ExecuteNonQuery( command, transaction  ); //here is the problem when I add argument , transaction it works
    
    //Here I try to read from temp table I have some DbCommand readCommand
    database.ExecuteNonQuery( readCommand, transaction ); 
