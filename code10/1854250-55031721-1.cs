    public class JsonInfo 
    {
      public string id { get; set; }
      public string name { get; set; }
      public JsonHasInfo has { get; set; }
      public JsonHas2Info has2 { get; set; }
    }
    public class JsonHasInfo
    {
      public bool CORS { get; set; }
      public bool CORS2 { get; set; }
    }
    public class JsonHas2Info
    {
      public bool CORS3 { get; set; }
      public bool CORS4 { get; set; }
    }
