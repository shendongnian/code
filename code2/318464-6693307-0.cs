    public RegionContext GetContext(string regionCode)
    {
    	RegionContext rc = null;
    	if (!this.contextCache.TryGetValue(regionCode.ToUpper(), out rc))
    	{
    		RegionContext newContext = new RegionContext(regionCode);
    		try
    		{
    			this.contextCache.Add(regionCode.ToUpper(), newContext);
    		}
    		catch
    		{
    			newContext.Dispose();
    			throw;
    		}
    
    		rc = newContext;
    	}
    
    	return rc;
    }
