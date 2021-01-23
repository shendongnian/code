    class WIP
    {
    	private static Dictionary<long, WIP> instances = new Dictionary<long, WIP>();
    	private WIP()
    	{
    		...
    	}
    	
    	
    	//  <Snipped> Various other properties... 
    	public Boolean Refresh()
    	{
    		//  This method fetches the data from DB and updates the object. 
    	}
    	
    	public static WIP Load(long ObjectID)
    	{
    		WIP wip = null;
    		if (instances.ContainsKey(ObjectID))
    		{
    			wip = instances[ObjectID];
    		}
    		else
    		{
    			wip = new WIP();
    			wip.ObjectID = ObjectID;
    			instances.Add(ObjectID, wip);
    		}
    		wip.Refresh();
    		
    		return wip;
    	}
    }
