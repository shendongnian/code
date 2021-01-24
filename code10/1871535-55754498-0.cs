    void Main()
    {
        var json1 = @"{
      ""type"": ""event_a"",
      ""data"": { }
    }
    ";
        var json2 = @"{
      ""type"": ""event_b"",
      ""data"": { }
    }
    ";
    
        var obj1 = JsonConvert.DeserializeObject<CallbackEvent>(json1, new DataConverter());
        var obj2 = JsonConvert.DeserializeObject<CallbackEvent>(json2, new DataConverter());
    }
    
    // Define other methods and classes here
    public class ClassA
    {
        public int Test { get; set; } = 2;
    }
    public class ClassB
    {
        public int Type { get; set; } = 1;
    }
    
    public class CallbackEvent
    {
        public string Type { get; set; }
    
        //[JsonConverter(typeof(DataConverter))]
        public object Data { get; set; }
    }
    
    public class DataConverter : JsonConverter<CallbackEvent>
    {
        public override CallbackEvent ReadJson(JsonReader reader, Type objectType, CallbackEvent existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            reader.Read();
    
            if (reader.TokenType != JsonToken.PropertyName || (string)reader.Value != "type")
            {
                throw new InvalidOperationException();
            }
    
            reader.Read();
    
            if (reader.TokenType != JsonToken.String)
            {
                throw new InvalidOperationException();
            }
            
            string typeValue = reader.Value?.ToString();
            
            reader.Read();
    
            if (reader.TokenType != JsonToken.PropertyName || (string)reader.Value != "data")
            {
                throw new InvalidOperationException();
            }
            
            reader.Read();
    
            object data = null;
    
            switch (typeValue)
            {
                case "event_a": data = serializer.Deserialize<ClassA>(reader); break;
                case "event_b": data = serializer.Deserialize<ClassB>(reader); break;
                default : data = serializer.Deserialize<object>(reader); break;
            }
    
            reader.Read();
    
            return new CallbackEvent()
            {
                Data = data,
                Type = typeValue,
            };
        }
    
        public override void WriteJson(JsonWriter writer, CallbackEvent value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
