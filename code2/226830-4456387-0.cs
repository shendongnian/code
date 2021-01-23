    using(TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew)){
    
        try{
            //Do something;
    
            scope.Complete();  //denotes the transaction completed successful.
        }
        catch(TransactionAbortedException ex)
        {
            
            //scope.Complete(); is never called, the transaction rolls back automatically.
        }
        catch(ApplicationException ex)
        {
            
        }
    }
