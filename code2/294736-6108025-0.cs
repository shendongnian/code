    using (var scope = new TransactionScope())
    {
    	using (var connection = new SqlConnection(connectString))
    	{
            // perform sql logic
            ...
    		
    	    scope.Complete(); 
    	}
    }
