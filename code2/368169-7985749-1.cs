    using ( CarSystemEntities context = new CarSystemEntities() ) { 
        if ( context.Connection.State != ConnectionState.Open ) { 
            context.Connection.Open(); 
        } 
    
        DbTransaction transaction = context.Connection.BeginTransaction(); 
        
        try { 
            <Data processing code here> 
            
            transaction.Commit(); 
            
        } catch ( Exception ex ) { 
            transaction.Rollback(); 
    
            <More exception code here as needed> 
        }             
    }
