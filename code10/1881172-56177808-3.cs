    public class ApiError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
