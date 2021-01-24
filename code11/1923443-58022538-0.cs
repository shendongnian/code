    internal static T TryParseJson<T>(this string json, string schema) where T : new()
    {
        var parsedSchema = JSchema.Parse(schema);
        try
        {
            var jToken = JToken.Parse(json);
            return jToken.IsValid(parsedSchema) ? jToken.ToObject<T>() : default(T);
        }
        catch (JsonException ex)
        {
            // optionally log the exception here
            return default(T);
        }
    }
