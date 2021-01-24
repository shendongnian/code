    public static class DictionaryExtensions
    {
    	public static void Update(this IDictionary src, IDictionary dst)
    	{
    		foreach (object srcKey in src.Keys)
    		{
    			foreach (object dstKey in dst.Keys)
    			{
    				if (dst.Contains(srcKey))
    				{
    					IDictionary d1 = src[srcKey] as IDictionary;
    					IDictionary d2 = dst[srcKey] as IDictionary;
    					if (d1 != null && d2 != null)
    					{
    						d1.Update(d2);
    					}
    					else
    						src[srcKey] = dst[srcKey];
    				}
    			}
    		}
    
    		foreach (object dstKey in dst.Keys)
    			if (!src.Contains(dstKey))
    				src.Add(dstKey, dst[dstKey]);
    	}
    }
		
