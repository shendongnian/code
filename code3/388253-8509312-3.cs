    public DataSet GetMyViewData()
    {
    	var results = HttpContext.Current.Cache["myViewResults"] as DataSet;
    	
    	if(results == null)
    	{
    		results = GetMyQueryResults();
    		HttpContext.Current.Cache["myViewResults"] = results;
    	}
    	
    	return results;
    }
