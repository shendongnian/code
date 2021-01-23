    // using Dbg = System.Diagnostics.Debug;
    XactIso.iso isoEntity = new XactIso.iso();
    using (isoEntity)
    {
        Dbg.WriteLine("Before: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
    
        var xactOpts = new TransactionOptions();
        xactOpts.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
    
        using (TransactionScope xact = new TransactionScope(TransactionScopeOption.Required, xactOpts))
        {
            Dbg.WriteLine("During: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
            xact.Complete();
        }
    
        Dbg.WriteLine("After: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
    
        isoEntity.usp_SetXactIsoLevel("ReadCommitted");
    
        Dbg.WriteLine("After Reset by SP Attempt: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
        // failed
    
        var xactOpts2 = new TransactionOptions();
        xactOpts2.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
        using (TransactionScope xact2 = new TransactionScope(TransactionScopeOption.Required, xactOpts2))
            Dbg.WriteLine("During Reset by XACT: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
        // works w/o commit
                    
        Dbg.WriteLine("After Reset by XACT: " + isoEntity.usp_GetXactIsoLevel().SingleOrDefault());
    }
