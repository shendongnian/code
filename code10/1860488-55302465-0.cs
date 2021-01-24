    var items = json.FromJson<Dictionary<string, object>[]>();
    var xml = new XElement("root", 
    							items
    								.Select(it => new XElement("element", 
    													it.Select(el => ToXml(el.Key, el.Value)))));	
    
    // Define other methods and classes here
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
    
    public static class Extensions
    {
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
