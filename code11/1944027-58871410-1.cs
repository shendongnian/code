    public static void EncodeAllProperties(object obj)
    {
    	var props = obj.GetType().GetProperties();
    	
    	foreach (var prop in props)
    	{
    		if (prop.PropertyType == typeof(string))
    		{
    			prop.SetValue(obj, Base64Encode(prop.GetValue(obj) as string));
    		}
    	}	
    }
    // From https://stackoverflow.com/a/11743162/11981207
    public static string Base64Encode(string plainText)
    {
    	var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
    	return System.Convert.ToBase64String(plainTextBytes);
    }
