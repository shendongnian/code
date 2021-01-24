    static T Parse<T>(string s)
    {
    	if (typeof(T).IsArray)
    	{
    		var TE = typeof(T).GetElementType();
    		switch (TE)
    		{
    			case var type when type == typeof(string):
    				return (T)((object)ParseArray<string>(s));
    
    			case var type when type == typeof(int):
    				return (T)((object)ParseArray<int>(s));
    
    			case var type when type == typeof(object ):
    				return (T)((object)ParseArray<object>(s));
    
    			default: throw new NotImplementedException();
    		}
    	}
    	var result = (T)Convert.ChangeType(s, typeof(T), CultureInfo.InvariantCulture);
	    return result;
    }
