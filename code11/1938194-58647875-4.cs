    public class BasicListResponse : Result
    {
        public List<BasicList> List { get; set; }
        [JsonExtensionData]
        private Dictionary<string, JToken> Data { get; set; }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            List = Data?.OrderBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Value.ToObject<BasicList>())
                        .ToList();
        }
    }
