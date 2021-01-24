    public class MyJson
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public partial class Data
    {
        [JsonProperty("available")]
        public bool Available { get; set; }
        // This should probably be a nullable DateTime
        [JsonProperty("expiration")]
        public object Expiration { get; set; } 
        // And this should probably be a string...
        [JsonProperty("registrant_email")]
        public object RegistrantEmail { get; set; }
    }
