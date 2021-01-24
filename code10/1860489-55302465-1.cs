    // Calling your JSON deserialization to create an array of dictionarys
    var items = json.FromJson<Dictionary<string, object>[]>();
    var xml = new XElement("root", 
    							items
    								.Select(it => new XElement("element", 
    													it.Select(el => ToXml(el.Key, el.Value)))));	
    
    // method to create xml from a key value pair
    XElement ToXml(string key, object item)
    {
    	if(item is JArray data){
    		var items = data.ToString()
    						.FromJson<Dictionary<string, object>[]>();
    		return new XElement(key, items.Select(dt => items
    								   					.Select(it => new XElement("element",
    													   		it.Select(el => ToXml(el.Key, el.Value))))));
    	}
    	return new XElement(key, item);
    }
    
    // In a separate class
    public static class Extensions
    {
        // This uses NewtonSoft.Json for deserialization
    	public static T FromJson<T>(this string json)
    	{
    		var serializer = new JsonSerializer();
    		using (var sr = new StringReader(json))
    		using (var jr = new JsonTextReader(sr))
    		{
    			var result = serializer.Deserialize<T>(jr);
    			return result;
    		}
    	}
    }
