    public class BirdCoup
    {
        [JsonProperty("bird-a")]
        [JsonConverter(typeof(TypeSafeEnumJsonConverter))] // sets the converter used for this type
        public BirdType BirdA { get; set; }
        [JsonProperty("bird-b")]
        [JsonConverter(typeof(TypeSafeEnumJsonConverter))] // sets the converter for this type
        public BirdType BirdB { get; set; }
    }
