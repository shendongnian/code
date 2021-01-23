    var stream = ... // In my case, a FileStream or HttpResponse stream
    using (var writer = new JsonTextWriter(new StreamWriter(stream)))
    {
    	writer.WriteStartObject();	
    	do
    	{
    		int row = 0;
    		string firstColumn = null;
    		while (await reader.ReadAsync())
    		{
    			if (row++ == 0)
    			{
    				firstColumn = reader.GetName(0);
    				writer.WritePropertyName(string.Format("{0}Collection", firstColumn));
    				writer.WriteStartArray();	
    			}
    			writer.WriteStartObject();
    			for (int i = 0; i < reader.FieldCount; i++)
    			{
    				if (!reader.IsDBNull(i)) { 
    					writer.WritePropertyName(reader.GetName(i));
    					writer.WriteValue(reader.GetValue(i));
    				}
    			}
    			writer.WriteEndObject(); 
    		}
    		writer.WriteEndArray();
    	} while (await reader.NextResultAsync());
    
    	writer.WriteEndObject();
    }
