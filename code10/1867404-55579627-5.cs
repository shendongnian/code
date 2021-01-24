    [JsonConverter(typeof(ResponseConverter))]
    public class Response
    {
        public Item[] Items { get; set; }
    }
