        public abstract class JsonCreationConverter<T> : JsonConverter
        {            
            protected abstract T CreateArray<TJsonType>(Type objectType, TJsonType jObject);
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException("Unnecessary because CanWrite is " +
                                              "false. The type will skip the converter.");
            }
            public override object ReadJson(JsonReader reader, Type objectType,
                object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
            
                JArray jArray;
                var target = default(T);
                try
                {
                    jArray = JArray.Load(reader);
                    target = CreateArray<JArray>(objectType, jArray);
                }
                catch (Exception ex)
                {                    
                    return null;
                }
                return target;
            }
            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }
            public override bool CanWrite
            {
                get { return false; }
            }
        }
