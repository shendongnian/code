    static void WriteRegistry(RegistryKey parentKey, String subKey, String valueName, Object value)
    {
            RegistryKey key;
    	try
    	{
    		key = parentKey.OpenSubKey(subKey, true);
    		if(key == null) //If the key doesn't exist.
                    {
    		   key = parentKey.CreateSubKey(subKey);
                    }
    		
    		//Set the value.
    		key.SetValue(valueName, value);
    
    		Console.WriteLine("Value:{0} for {1} is successfully written.", value, valueName);
    	}
    	catch(Exception e)
    	{
    		Console.WriteLine("Error occurs in WriteRegistry" + e.Message);
    	}
    }
