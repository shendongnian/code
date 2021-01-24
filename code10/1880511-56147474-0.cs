    public class MyResponse
    {
      public string Version { get; set; }
      public string StatusCode { get; set; }
      public string RequestId { get; set; }
      public bool Success { get; set; }
      public SomeResult Result { get; set; }
      public Dictionary<string, List<string>>  ValidationMessages {get;set;}
    }
