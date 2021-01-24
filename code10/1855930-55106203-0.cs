    public class SenstiveData : Attribute
    {
    }
    public class SenstivieJsonConverter : JsonConverter
    {
        private readonly Type[] _types;
        public SenstivieJsonConverter(params Type[] types)
        {
            _types = types;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var props = _types[0].GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SenstiveData)));
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr as SenstiveData != null)
                    {
                        prop.SetValue(value, "#####");
                    }
                }
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
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
