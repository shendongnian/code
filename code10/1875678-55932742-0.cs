    static ConcurrentDictionary<int, object> taskDictionary=new ConcurrentDictionary<int, object>();
    static void ThreadHandler(int key)
    {   
    	try
    	{
    		object obj;
    		
    		// Remove object with key = 'key', or create a new object if it does not yet exist
    		taskDictionary.TryRemove(key, out obj);
    		
    		// Do whatever you need to do with 'obj'
    		
    		// Add the object (back) to the dictionary if necessary
    		taskDictionary.GetOrAdd(key, obj);
    	}
    	finally
    	{
    	}
    }
