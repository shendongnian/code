    db.Connection.StateChange += ConnectionStateChange;
    
    void ConnectionStateChange(object sender, System.Data.StateChangeEventArgs e)
    {
        if (e.CurrentState == System.Data.ConnectionState.Open) 
             db.ExecuteStoreCommand("PRAGMA foreign_keys = true;");            
    }
