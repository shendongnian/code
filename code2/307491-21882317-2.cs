    // Try to create the Command as early as possible with a valid Connection object
    string commandString = "UPDATE Mytable SET s_id=@s_id where id = @id;";
    var command = new SqlCommand(commandString, connection);
    
    // Then define a Transaction object with your Connection
    var transaction = connection.BeginTransaction();
    command.Transaction = transaction;
    // Now iterate through your array
    for(int i=0; i<array.Length; i++)
    {
      command.Parameters.Add("@s_id", SqlDbType.YourType).Value = items[i].SId;
      command.Parameters.Add("@id", SqlDbType.YourType).Value = items[i].Id;
      command.ExecuteNonQuery(); // Not executed at this point
    }
    // And now execute it with the possibility to rollback all commands when it fails
    try {  transaction.Commit(); } // Here the execution is committed to the DB
    catch (Exception)
    {
      transaction.Rollback();
      throw;
    }
