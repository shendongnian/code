    public class DatamapItem
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> DatamapItemFields { get; set; } = new Dictionary<string, JToken>();
        public Dictionary<string, JToken> datamapKey { get; set; } = new Dictionary<string, JToken>();
        public Dictionary<string, JToken> datamapKey1 { get; set; } = new Dictionary<string, JToken>();
    }
    public class RootObject
    {
        public List<DatamapItem> datamapItems { get; set; }
    }
