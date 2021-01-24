    public class ValueTupleConverter<U,V> : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ValueTuple<U,V>) == objectType;
        }
    
        public override object ReadJson(Newtonsoft.Json.JsonReader reader,Type objectType,object existingValue,Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null) return null;
    
            var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
    		var properties = jObject.Properties().ToList();
            return new ValueTuple<U, V>(jObject[properties[0].Name].ToObject<U>(), jObject[properties[1].Name].ToObject<V>());
        }
    
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    	
    }
