      public class Response
      {
          [JsonProperty(Required = Required.Default)]
          public string Domain { get; set; }
          [JsonProperty(Required = Required.Always)]
          public Data Data { get; set; }
      }
