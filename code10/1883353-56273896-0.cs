    public class Permitted
    {
        [JsonProperty("read")]
        public string[] Read { get; set; }
        [JsonProperty("update")]
        public string[] Update { get; set; }
        [JsonProperty("delete")]
        public string[] Delete { get; set; }
    }
