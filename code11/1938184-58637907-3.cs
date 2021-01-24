    public class Result
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cdate")]
        public DateTimeOffset Cdate { get; set; }
        [JsonProperty("private")]
        public long Private { get; set; }
        [JsonProperty("userid")]
        public long UserId { get; set; }
        [JsonProperty("subscriber_count")]
        public long SubscriberCount { get; set; }
    }
    public class Results
    {
        [JsonProperty("0")]
        public Result Result1 { get; set; }
        [JsonProperty("1")]
        public Result Result2 { get; set; }
        [JsonProperty("result_code")]
        public long ResultCode { get; set; }
        [JsonProperty("result_message")]
        public string ResultMessage { get; set; }
        [JsonProperty("result_output")]
        public string ResultOutput { get; set; }
    }
