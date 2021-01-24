    private int SomeMagic(List<string> first, List<string> second)
    {
    	if (first.Count < second.Count)
    	{
    		return - 1;
    	}
    
    	for (int i = 0; i <= first.Count - second.Count; i++)
    	{
    		List<string> partialFirst = first.GetRange(i, second.Count);
    		if (partialFirst.AsQueryable().Intersect(second).Count() == second.Count)
    			return i;
    	}
    
    	return -1;
    }
