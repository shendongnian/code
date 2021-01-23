    [JsonObject]
    public class ClassToSerializeWithJson
    {
        [JsonProperty]
        public TypeThatIsJsonSerializable PropertySerializedWithJsonSerializer {get; set; }
        [JsonProperty]
        [JsonConverter(typeof(JsonXmlConverter<TypeThatIsXmlSerializable>))]
        public TypeThatIsXmlSerializable PropertySerializedWithCustomSerializer {get; set; }
    }
