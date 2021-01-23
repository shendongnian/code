    public static AttributeCustom GetAttributeCustom<T>(string method) where T : class
    {
    	try
    	{
    		return ((AttributeCustom)typeof(T).GetMethod(method).GetCustomAttributes(typeof(AttributeCustom), false).FirstOrDefault());
    	}
    	catch(SystemException)
    	{
    		return null;
    	}
    }
