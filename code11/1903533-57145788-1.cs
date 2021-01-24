    public class GetResponse
    {
        [JsonProperty(Required = Required.Always)]
        public ResponseHeader respHead { get; private set; }
        [JsonProperty(Required = Required.Always)]
        public Response resp { get; private set; }
    }
