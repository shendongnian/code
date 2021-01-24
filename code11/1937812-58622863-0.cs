    public class YourObject
    {
        [JsonProperty("app_ids")]
        public string AppIds{ get; set; }
    
        [JsonProperty("ApplicationIds")]
        private string AppIds2 { set { AppIds = value; } }
    }
