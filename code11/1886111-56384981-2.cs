    public class Tags
    {
    	[JsonProperty("tiger:maxspeed")]
    	[JsonConverter(typeof(MaxSpeedConverter))]
    	public int MaxSpeed { get; set; }
    }
    
    class MaxSpeedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
    	    // CanConvert is not called when the converter is used with a [JsonConverter] attribute
            return false;   
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
    		string val = (string)reader.Value;
    		
    		int speed;
    		if (val != null && int.TryParse(val.Split(' ')[0], out speed))
    			return speed;
    
    		return 0;
    	}
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((int)value + " mph");
        }
    }
