    public class GetResponse
    {
        [JsonProperty(Required = Required.Always)]
        public ResponseHeader respHead { get; set; }
        [JsonProperty(Required = Required.Always)]
        public Response resp { get; set; }
    }
