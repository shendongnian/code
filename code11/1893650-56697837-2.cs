     private DbContext getDbContext(bool statement)
     {
         if(statement)
    	   return _dbcontext1;
    	 else if(statement2)
    	   return _dbcontext2;
    	 else
    	   return _someOtherDbContext;
     }
 
    private void foo()
    {
     Model data =  (from table in getDbContext(statement)
                   where table.ref_no == ref_no
                   select new Model
                          {
                                 ...
                          });
    }
