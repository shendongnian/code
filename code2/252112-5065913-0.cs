    public class Response
    {
        [JsonProperty(PropertyName = "total_rows")]
        public int TotalRows { get; set; }
        public IList<MyPoco> Data { get; set; }
    }
