    using( YourConnectionObject )
    {
       ... open connection ...
       ... create your sql querying object... and command 
       SQLCommand.Connection = YourConnectionObject;
    
       Execute your Query
    
       SQLCommand.CommandText = "a new sql-select statement";
    
       Execute your NEW query while connection still open/active
    
       SQLCommand.CommandText = "a third sql-select statement";
    
       Execute your THIRD query while connection still open/active
    
       ... close your connection
    }
