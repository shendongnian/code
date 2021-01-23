    _db = DatabaseFactory.CreateDatabase();
    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
    {
        _command = _db.GetStoredProcCommand(storedProcedure);
        DataSet ds = _db.ExecuteDataSet(_command);
    
        ts.Complete();
    }
 
