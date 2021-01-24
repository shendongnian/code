     public class Values
    {
        [JsonProperty("page views")]
        public Dictionary<string, int> page_views { get; set; }
    }
    public class Data
    {
        public List<string> series { get; set; }
        public Values values { get; set; }
    }
    public class RootObject
    {
        public string computed_at { get; set; }
        public int legend_size { get; set; }
        public Data data { get; set; }
    }
