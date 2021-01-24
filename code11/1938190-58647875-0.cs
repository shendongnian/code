    public class Result
    {
        [JsonProperty("result_code")]
        public int ResultCode { get; set; }
        [JsonProperty("result_message")]
        public string ResultMessage { get; set; }
        [JsonProperty("result_output")]
        public string ResultOutput { get; set; }
        public List<BasicList> BasicLists { get; set; }
        [JsonExtensionData]
        private Dictionary<string, JToken> Data { get; set; }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BasicLists = Data?.OrderBy(kvp => kvp.Key)
                              .Select(kvp => kvp.Value.ToObject<BasicList>())
                              .ToList();
        }
    }
