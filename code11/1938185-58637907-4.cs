    public class Results
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> Items;
        [JsonProperty("result_code")]
        public long ResultCode { get; set; }
        [JsonProperty("result_message")]
        public string ResultMessage { get; set; }
        [JsonProperty("result_output")]
        public string ResultOutput { get; set; }
    }
    public class Result
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Cdate { get; set; }
        public long Private { get; set; }
        public long UserId { get; set; }
        public long SubscriberCount { get; set; }
        public override string ToString()
        {
            return $"Id={Id},Name={Name},CDate={Cdate.ToString()},Private={Private},UserId={UserId},SubscriberCount={SubscriberCount}";
        }
    }
