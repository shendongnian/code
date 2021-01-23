    public void RunOracleTransaction(string connectionString) {
      using (OracleConnection connection = new OracleConnection(connectionString))
      {
        connection.Open();
        OracleCommand command = connection.CreateCommand();
        OracleTransaction transaction;
        // Start a local transaction
        transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        // Assign transaction object for a pending local transaction
        command.Transaction = transaction;
        try
        {
            command.CommandText = 
                "INSERT INTO contactMaster
                   (contactID, FName, MName, LName) 
                 VALUES
                   (contactID.NextVal, 'John', 'G', 'Garnet')";
            command.ExecuteNonQuery();
            command.CommandText = 
                "INSERT INTO contactPhone
                   (contactPhoneID, contactID, contactType, phonenum)     
                 VALUES
                   (contactPhoneID.NextVal, 1, 2, 1234567890)";
            command.ExecuteNonQuery();
            command.CommandText = 
                "INSERT INTO contactAddress
                   (contactAddressID, contactID, addressType, PHN, Street, City)
                 VALUES
                   (contactAddressID.NextVal, 1, 1, 287, 'Blooper St', 'New Yor')";
            command.ExecuteNonQuery();
            transaction.Commit();
            Console.WriteLine("Both records are written to database.");
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine(e.ToString());
            Console.WriteLine("Neither record was written to database.");
        }
      }
    }
