    try
    {
    	using (var scope = new TransactionScope())
        {
    		using (var conn = new SqlConnection("connection string"))
    		{
    			
    		}
    		
    		// The Complete method commits the transaction. If an exception has been thrown,
            // Complete is not  called and the transaction is rolled back.
            scope.Complete();
    	}
    }
    catch (TransactionAbortedException ex)
    {
    	// log
    }
