    private void MyTest()
    {
    	var result = FetchListLinq(true);
    	result = FetchDbContextLinq(true);
    	result = FetchListLinq();
    	result = FetchDbContextLinq();
    }
    
    private List<object> FetchListLinq(bool? allocated = null)
    {
    	var myList = new List<dynamic>() { new { Id = 1, Allocated = true, Active = true }, new { Id = 2, Allocated = false, Active = true }, new { Id = 3, Allocated = true, Active = false } };
       return (from x in myList
    				   where x.Active && (allocated == null || x.Allocated == allocated.Value)
    				   select x).ToList();
    }
    
    private List<object> FetchDbContextLinq(bool? allocated = null)
    {
    	// allocated = allocated ?? (bool?)null; // fix for Linq to SQL or Linq to Entity
    	var notWorking = (from x in DbContext.Something
    					  where x.Active && (allocated == null || x.Allocated == allocated.Value)
    					  select x).ToList();
    }
