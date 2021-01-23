    object MyDeserialize(string s) {
    	using (var jr = new JsonTextReader(new StringReader(s)))
    	{
    		if (jr.Read() && jr.TokenType == JsonToken.StartObject) {
    			while (jr.Read() && jr.TokenType == JsonToken.PropertyName) {
    				switch ((string)jr.Value)
    				{
    					case "MagicKey1": return JsonConvert.DeserializeObject<MagicType1>(s);
    					case "MagicKey2": return JsonConvert.DeserializeObject<MagicType2>(s);
    				}
    				jr.Skip();
    			}
    			if (jr.TokenType != JsonToken.EndObject)
    				throw new ArgumentException("Expected end object");
    			throw new ArgumentException("Couldn't determine object type");
    		}
    		else
    			throw new ArgumentException("Expected start object");
    	}
    }
    
    void Main() {
        var s = "{ \"MagicKey1\": [], \"b\": \"asdaasd\", \"c\": { \"a\": 5 } }";
    	MyDeserialize(s);
    }
