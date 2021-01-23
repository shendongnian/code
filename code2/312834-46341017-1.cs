    public static AttributeHelp GetAttributeHelp<T>(string method) where T : class
    {
    	try
    	{
    		return ((AttributeHelp)typeof(T).GetMethod(method).GetCustomAttributes(typeof(AttributeHelp), false).FirstOrDefault());
    	}
    	catch(SystemException)
    	{
    		return null;
    	}
    }
