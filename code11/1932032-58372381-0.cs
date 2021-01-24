    public class DoubleJsonConverter : JsonConverter<double>
    {
    	public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    	{
    		try
    		{
    			return reader.GetDouble();
    		}
    		catch (Exception)
    		{
    			return 0.0;
    		}
    	}
    
    	public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    	{
    		try
    		{
    			writer.WriteNumberValue((decimal)value);
    		}
    		catch (Exception)
    		{
    			writer.WriteNumberValue(0.0);
    		}
    	}
    }
