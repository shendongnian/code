    // Try to create the Command as early as possible with a valid Connection object
    string connectionString = "UPDATE Mytable SET s_id=@s_id where id = @id;";
    var command = new SqlCommand(connectionString, connection);
    
    // Then define a Transaction object with you Connection
    var transaction = connection.BeginTransaction();
    // Now iterate through your array
    for(int i=0; i<array.Length; i++)
    {
      command.Parameters.Add("@s_id", SqlDbType.YourType).Value = items[i].SId;
      command.Parameters.Add("@id", SqlDbType.YourType).Value = items[i].Id;
      command.ExecuteNonQuery(); // Not executed at this point
    }
    // And now execute it with the possibility to rollback all commands when it fails
    try {  transaction.Commit(); } // Here it's executed
    catch (Exception)
    {
      transaction.Rollback();
      throw;
    }
