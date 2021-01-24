      public partial class Data
      {
          [JsonProperty(Required = Required.Default)]
          public bool Available { get; set; }
          [JsonProperty(Required = Required.AllowNull)]
          public object Expiration { get; set; } 
      
          [JsonProperty("registrant_email" ,Required = Required.AllowNull)]
          public object RegistrantEmail { get; set; }
      }
      var response = JsonConvert.DeserializeObject<Response>(finishResponse);
      Console.WriteLine(response.Data.available);
