    public void MainMethod()
    {
    	var object1 = CreateFirstObject();
    	try
    	{
    		SomeCollectionProperty.Add(object1);
    				
    		var object2 = CreateSecondObject();
    		try
    		{
    			SomeCollectionProperty.Add(object2);
    		}
    		catch
    		{
    			object2.Dispose();
    			throw;
    		}
    	}
    	catch
    	{
    		object1.Dispose();
    		SomeCollectionProperty.Remove(object1);	// Not supposed to throw if item does not exist in collection.
    				
    		throw;
    	}
    }
