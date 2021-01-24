    public class SalesforceListResponse<T>
    {
        [JsonProperty("totalSize")]
        public string TotalSize { get; set; }
        [JsonProperty("done")]
        public bool Done { get; set; }
        [JsonProperty("nextRecordsUrl")]
        public string NextRecordsUrl { get; set; }
        [JsonProperty("records")]
        public T[] Records { get; set; }
    }
