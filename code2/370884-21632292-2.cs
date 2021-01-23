    /// <summary>Creates a new reader for the specified jObject by copying the settings
    /// from an existing reader.</summary>
    /// <param name="reader">The reader whose settings should be copied.</param>
    /// <param name="jObject">The jObject to create a new reader for.</param>
    /// <returns>The new disposable reader.</returns>
    public static JsonReader CopyReaderForObject(JsonReader reader, JObject jObject)
    {
        JsonReader jObjectReader = jObject.CreateReader();
        jObjectReader.Culture = reader.Culture;
        jObjectReader.DateFormatString = reader.DateFormatString;
        jObjectReader.DateParseHandling = reader.DateParseHandling;
        jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
        jObjectReader.FloatParseHandling = reader.FloatParseHandling;
        jObjectReader.MaxDepth = reader.MaxDepth;
        jObjectReader.SupportMultipleContent = reader.SupportMultipleContent;
        return jObjectReader;
    }
