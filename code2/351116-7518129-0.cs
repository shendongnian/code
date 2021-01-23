    public bool CompareTables(DataTable a, DataTable b)
    {
    	if(a.Rows.Count != b.Rows.Count)
    	{
    		// different size means different tables
    		return false;
    	}
    		
    	foreach(int rowIndex=0; rowIndex<a.Rows.Count; ++rowIndex)
    	{
    		if(!arraysHaveSameContent(a.Rows[rowIndex].ItemArray, b.Rows[rowIndex].ItemArray,))
    		{
    			return false;
    		}
    	}
    	
    	// Tables have same data
    	return true;
    }
    
    private bool arraysHaveSameContent(object[] a, object[] b)
    {
    	// Here your super cool method to compare the two arrays with LINQ,
    	// or if you are a loser do it with a for loop :D
    }
