    class Grab 
    {
        [JsonProperty(PropertyName = "PS4_Beta")]
        public List<Data> PS4_Beta{ get; set; }
        public class Data
        {
            [JsonProperty(PropertyName = "Firmware")]
            public string Firmware { get; set; }
            [JsonProperty(PropertyName = "Size")]
            public string Size { get; set; }
            [JsonProperty(PropertyName = "MD5")]
            public string MD5 { get; set; }
        }
    }
    
