    public IEnumerable<string> columnSortList
    {
    	get
    	{
    		if (ColumSort == null)
    		{
    			return null
    		}
    		else
    		{
    			return ColumnSort.Split(',')
    						 .Select(x => x.Trim())
    						 .Where(x => !string.IsNullOrWhiteSpace(x))
    						 .AsEnumerable();
    		}
    	}
    }
  
