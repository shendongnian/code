    public class TextPropertyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // not covered here
        }
        // A value can be either single string or object
        // Return a TextProperty in both cases
        private TextProperty ParseValue(JToken value) 
        {
            switch(value.Type)
            {
                case JTokenType.String:
                    return new TextProperty { text = value.ToObject<string>() };
                case JTokenType.Object:
                    return value.ToObject<TextProperty>();
                default:
                    return null;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // You'll start either with a single value (we'll convert to list of one value) or an array (list of several values then)
            switch(reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.StartObject:
                    return new List<TextProperty> { ParseValue(JToken.Load(reader)) };
                case JsonToken.StartArray:
                    var a = JArray.Load(reader);
                    var l = new List<TextProperty>();
                    foreach(var v in a)
                        l.Add(ParseValue(v));
                    return l;
                default:
                    return null;
            }
        }
        public override bool CanConvert(Type objectType) => false;
    }
