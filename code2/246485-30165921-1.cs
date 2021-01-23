    public class ConfigModel : JsonObject
    {
        [JsonProperty("altFormat", NullValueHandling = NullValueHandling.Ignore)]
        public String altFormat { get; set; }
        [JsonProperty("onClose", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(FunctionConverter))]
        public String onClose { get; set; }
    }
