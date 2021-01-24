    public static class DeserializeExtensions
    {
    	private static JsonSerializerSettings defaultSerializerSettings = new JsonSerializerSettings();
    	
    	// set this up how you need to!
    	private static JsonSerializerSettings featureXSerializerSettings = new JsonSerializerSettings();
    
    
    	public static T Deserialize<T>(this string json)
    	{		
    		return JsonConvert.DeserializeObject<T>(json, defaultSerializerSettings);
    	}
    	
    	public static T DeserializeCustom<T>(this string json, JsonSerializerSettings settings)
    	{
    		return JsonConvert.DeserializeObject<T>(json, settings);
    	}
    	
    	public static T DeserializeFeatureX<T>(this string json)
    	{
    		return JsonConvert.DeserializeObject<T>(json, featureXSerializerSettings);
    	}
    }
