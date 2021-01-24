    public class MyClass {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("operation")]
        public string Operation { get; set; }
        [JsonProperty("filter")]
        public string Filter { get; set; }
        [JsonProperty("currentOrderList")]
        public string[] CurrentOrderList { get; set; }
    }
