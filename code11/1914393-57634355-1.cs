    public IEnumerable<string> columnSortList
    {
    	get
    	{
    		if (ColumSort == null)
    		{
    			return new List<string>();
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
  
