    public override object ReadJson(JsonReader reader,
                                    Type objectType,
                                    object existingValue,
                                    JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;
        // Load JObject from stream
        JObject jObject = JObject.Load(reader);
        // Create target object based on JObject
        T target = Create(objectType, jObject);
        // Populate the object properties
        using (JsonReader jObjectReader = CopyReaderForObject(reader, jObject))
        {
            serializer.Populate(jObjectReader, target);
        }
        return target;
    }
