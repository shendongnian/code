    public static class DeserializeExtensions
    {
    	private static JsonSerializerOptions defaultSerializerSettings = new JsonSerializerOptions();
    	
    	// set this up how you need to!
    	private static JsonSerializerOptions featureXSerializerSettings = new JsonSerializerOptions();
    
    
    	public static T Deserialize<T>(this string json)
    	{		
    		return JsonSerializer.Deserialize<T>(json, defaultSerializerSettings);
    	}
    	
    	public static T DeserializeCustom<T>(this string json, JsonSerializerOptions settings)
    	{
    		return JsonSerializer.Deserialize<T>(json, settings);
    	}
    	
    	public static T DeserializeFeatureX<T>(this string json)
    	{
    		return JsonSerializer.Deserialize<T>(json, featureXSerializerSettings);
    	}
    }
