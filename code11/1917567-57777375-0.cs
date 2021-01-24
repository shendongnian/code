    public class JsonBigFileReader
    {
    	static string ReadSingleObject(JsonTextReader reader)
    	{
    		StringBuilder sb = new StringBuilder();
    
    		using (var sw = new StringWriter(sb))
    		{
    			using (var writer = new JsonTextWriter(sw))
    			{
    				writer.WriteToken(reader, true);    //  writes current token including its children (meaning the whole object)
    			}
    		}
    		return sb.ToString();
    	}
    
    	public IEnumerable<string> ReadArray(string fileName)
    	{
    		var file = new FileInfo(fileName);
    		using (var sr = new StreamReader(file.OpenRead()))
    		using (var reader = new JsonTextReader(sr))
    		{
    			reader.Read();
    			while (reader.Read())
    			{
    				if (reader.TokenType == JsonToken.StartObject)
    				{
    					yield return ReadSingleObject(reader);
    				}
    			}
    		}
    	}
    }
