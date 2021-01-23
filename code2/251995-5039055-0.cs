    using (TransactionScope ts = new TransactionScope())
    {
        blah1.SubmitChanges()
    
        blah2.SubmitChanges();
    
        ts.Commit();
    }
