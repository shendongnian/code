    SqlDataReader rdr = cmd.ExecuteReader();
    
    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);    
    
    using (JsonWriter jsonWriter = new JsonTextWriter(sw)) 
    {    
    	jsonWriter.WriteStartArray();
    
    	while (rdr.Read())
    	{
    		jsonWriter.WriteStartObject();
    
    		int fields = rdr.FieldCount;
    
    		for (int i = 0; i < fields; i++)
    		{ 
    			jsonWriter.WritePropertyName(rdr.GetName(i));
    			jsonWriter.WriteValue(rdr[i]);
    		}
    
    		jsonWriter.WriteEndObject();
    	}
    
    	jsonWriter.WriteEndArray();
    }
