    [JsonConverter(typeof(MyJsonConverter))]
    public class A
    {
        public MyType Value { get; set; }
    }
    public class AConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(A);
        public override bool CanWrite => false;
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
    
            // Check if the keys contains "Name"
    		string name = jObject["Name"]?.ToString();
    		
    		var a = new A();
            
    		if (name != null)
    		{
    			a.Value = new MyType
    			{
    				Name = name,
    				Value = jObject["Value"].Value<double>()
    			};
    		}
    		else
            {
    		    a.Value = jObject["Value"].ToObject<MyType>();
            }
            
            return a;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
