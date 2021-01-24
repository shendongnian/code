    public class SensitiveDataAttribute: Attribute
    {
    }
    public sealed class SensitiveDataJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Any(x => x is SensitiveDataAttribute))
                    prop.SetValue(value, "#####");
            }
    
            var t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                o.WriteTo(writer);
            }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
    
        public override bool CanRead => false;
    
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
