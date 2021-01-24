    internal class Result<T>
    {
        [JsonProperty("success")]
        public int Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
