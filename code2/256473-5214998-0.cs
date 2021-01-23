    using( TransactionScope ts = new TransactionScope() ) { 
        try 
        { 
            logAdap.InsertLog(.....);
            foreach (.....)
	        {
		        measAdap.InsertMeas(.....); 
                foreach (.....)
	            {
		            valAdap.InsertVal(.....);
	            }
	        }
            // Complete the transaction
            ts.Complete();
        }
        catch (Exception ex) 
        { 
            // Your error handling here.
            // No need to rollback each table adapter. That along with all the 
            // transaction is done for you when exiting the using block without 
            // calling Complete() on the TransactionScope.
        }}
