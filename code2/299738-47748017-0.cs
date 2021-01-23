    Add()
    {
         bool isDuplicate = false;
         try
         {
           //add to database 
         }
         catch (DbUpdateException ex)
         {
    	   if (dbUpdateException.InnerException != null)
    	   {
    		  var sqlException = dbUpdateException.InnerException.InnerException as SqlException;
    		  if(sqlException == null)
    			 isDuplicate = IsDuplicate(sqlException);
    	   } 
         }
         catch (SqlException ex)
         {
    	    isDuplicate = IsDuplicate(ex);
         }	
         if(isDuplicate){
           //handle here
         }
    }
    bool IsDuplicate(SqlException sqlException)
    {
    	switch (sqlException.Number)
    	{
    		case 2627:
    			return true;
    		default:
    			return false;
        }
    }
