    public static class SerializationHelper
    {
    	public static void SerializeData<T>(this T obj, Stream streamObject)
    	{
    		if (obj == null || streamObject == null)
    			return;
    
    		var ser = new DataContractJsonSerializer(typeof(T));
    		ser.WriteObject(streamObject, obj);
    	}
    
    	public static T DeserializeData<T>(Stream streamObject)
    	{
    		if (streamObject == null)
    			return default(T);
    
    		var ser = new DataContractJsonSerializer(typeof(T));
    		return (T)ser.ReadObject(streamObject);
    	}
    }
