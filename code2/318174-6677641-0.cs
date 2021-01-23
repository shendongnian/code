    Public class User : IHasTimeStamp
    (
        public void DoTimeStamp()
    	{
    		if(dataContext.Entry<User>(this).State == System.Data.EntityState.Added)        
    		{            
    			//add creation date_time            
    			this.CreationDate=DateTime.Now;            
    		}        
    		
    		if(dataContext.Entry<User>(this).State == System.Data.EntityState.Modified)        
    		{            
    			//update Updation time            
    			this.UpdatedOnDate=DateTime.Now;        
    		}
    	}
    }
