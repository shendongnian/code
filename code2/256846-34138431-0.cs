    public bool IsIPhone
    {
    	get
    	{
    		if (!UserAgent.ToUpper().Contains("LIKE IPHONE"))
    		{
    			return UserAgent.ToUpper().Contains("IPHONE");
    		}
    		return false;
    	}
    }
