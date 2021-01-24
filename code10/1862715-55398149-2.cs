    class DictionaryResponseConverter : JsonConverter<ResponseBase>
    {
        public override ResponseBase ReadJson(
            JsonReader reader, Type objectType,
            ResponseBase existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            // find the correct T and call the internal function through reflection
            // as DictionaryResponse<T> is sealed, we don't care about inheritance
            return (ResponseBase)GetType()
                .GetMethod(nameof(InternalReadJson),
                           BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(objectType.GetGenericArguments()[0])
                .Invoke(this, new object[]
                {
                    reader,
                    existingValue,
                    hasExistingValue,
                    serializer
                });
        }
        DictionaryResponse<T> InternalReadJson<T>(
            JsonReader reader,
            DictionaryResponse<T> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            var error = (string)obj["error"];
            bool hadError = obj.Remove("error");
            //var result = new DictionaryResponse<T>();
            var result = hasExistingValue ? existingValue : new DictionaryResponse<T>();
            foreach (var kvp in obj)
                result[kvp.Key] = kvp.Value.ToObject<T>();
            if (hadError)
                result.Error = error;
            return result;
        }
        public override void WriteJson(
            JsonWriter writer, ResponseBase value, JsonSerializer serializer)
        {
            // don't care about serialization
            throw new NotImplementedException();
        }
    }
