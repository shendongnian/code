    public class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cdate")]
        public string Cdate { get; set; }
        [JsonProperty("private")]
        public string Private { get; set; }
        [JsonProperty("userid")]
        public string UserId { get; set; }
        [JsonProperty("subscriber_count")]
        public int SubscriberCount { get; set; }
    }
    public class Results
    {
        [JsonProperty("0")]
        public Result Result1 { get; set; }
        [JsonProperty("1")]
        public Result Result2 { get; set; }
        [JsonProperty("result_code")]
        public int ResultCode { get; set; }
        [JsonProperty("result_message")]
        public string ResultMessage { get; set; }
        [JsonProperty("result_output")]
        public string ResultOutput { get; set; }
    }
