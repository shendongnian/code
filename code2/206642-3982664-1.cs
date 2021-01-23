    public class TheResponse {
      public RESULT result { get; set; }
      public object error { get; set; }
    }
    
    public class RESULT {
      public CAMPAIGN_ID campaign_ID { get; set; }
    }
    public class CAMPAIGN_ID {
      public string name { get; set; }
      public string from_name { get; set; }
      public string from_email { get; set; }
      public string reply_to_email { get; set; }
      public string created_on { get; set; }
    }
