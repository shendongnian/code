        public class SingleValueArrayConverter<T> : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                object retVal = new Object();
                if (reader.TokenType == JsonToken.StartObject)
                {
                    T instance = (T)serializer.Deserialize(reader, typeof(T));
                    retVal = new List<T>() { instance };
                } else if (reader.TokenType == JsonToken.StartArray) {
                    retVal = serializer.Deserialize(reader, objectType);
                }
                return retVal;
            }
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
        }
