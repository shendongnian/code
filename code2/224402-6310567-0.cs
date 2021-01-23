    try
    {
        this.command = command;     // store for disposal
        
        if (command.Connection.State != ConnectionState.Open)
            command.Connection.Open();
        
        dataReader = command.ExecuteReader(CommandBehavior.SequentialAccess);
        dataReader.Read();            
    }
    catch (Exception ex)
    {
        Dispose();
        throw;
    }
