    using (var trans = new TransactionScope(TransactionScopeOption.RequiresNew))
    {
        var cn  = new OracleConnection();
        // perform PL/SQL
        
        if (success())
        {
            // this is the "Commit"
            trans.Complete();
        }
    }
