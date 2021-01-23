    public static object COMCreateObject (string sProgID)
    {
    	// We get the type using just the ProgID
    	Type oType = Type.GetTypeFromProgID (sProgID);
    	if (oType != null)
    	{					
    		return Activator.CreateInstance(oType);
    	}
    			
    	return null;
    }
