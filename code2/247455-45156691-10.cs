    //This lives in a helper class
    public static ConvertDynamic<T>(dynamic data)
    {
    	 return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Newtonsoft.Json.JsonConvert.SerializeObject(data));
    }
    
    //Same helper, but in an extension class (public static class),
    //but could be in a base class also.
    public static ToModelList<T>(this List<dynamic> list)
    {
    	List<T> retList = new List<T>();
    	foreach(dynamic d in list)
    	{
    		retList.Add(ConvertDynamic<T>(d));
    	}
    }
