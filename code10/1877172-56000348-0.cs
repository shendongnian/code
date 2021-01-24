    public class CustomLocationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json= JToken.ReadFrom(reader);
            var typeToken = json.SelectToken("type"); // or ??json.SelectToken("Type");
            if(typeToken ==null) return null;         //  
            var type= ResolveILocationTypeRuntime((int)typeToken);
            var location = DeserializeLocationRuntime(json, type);
            return location;
        }
        private Type ResolveILocationTypeRuntime(int type)
        {
            switch (type)
            {
                case 1:
                    return typeof(StreetLocation);
                case 2:
                    return typeof(GeoCoordinateLocation);
                default:
                    throw new ArgumentOutOfRangeException("type should be 1|2");
            }
        }
        private ILocation DeserializeLocationRuntime(JToken json, Type locationType)
        {
            MethodInfo mi = typeof(JToken)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == "ToObject" && m.GetParameters().Length == 0 && m.IsGenericMethod)
                .FirstOrDefault()
                ?.MakeGenericMethod(locationType);
            var location = mi?.Invoke(json, null);
            return (ILocation)location;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var location = value as ILocation;
            var type = ResolveILocationTypeRuntime(location.Type);
            serializer.Serialize(writer, location, type );
        }
    }
