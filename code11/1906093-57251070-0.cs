    public class ApiResponseObject<T>
    {
        [JsonProperty("paging")]
        public Paging PagingInfo { get; set; }
        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
