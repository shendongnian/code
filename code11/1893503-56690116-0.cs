    public partial class Test
    {
        [JsonProperty("removed")]
        public Removed Removed { get; set; }
    }
    public partial class Removed
    {
        [JsonProperty("series")]
        public List<long> Series { get; set; }
        [JsonProperty("unit")]
        public List<long> Unit { get; set; }
    }
