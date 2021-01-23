    public class LogEntry
    {
      public string Details { get; set; }
      public DateTime LogDate { get; set; }
    }
     
    [Test]
    public void WriteJsonDates()
    {
      LogEntry entry = new LogEntry
      {
        LogDate = new DateTime(2009, 2, 15, 0, 0, 0, DateTimeKind.Utc),
        Details = "Application started."
      };
     
      string defaultJson = JsonConvert.SerializeObject(entry);
      // {"Details":"Application started.","LogDate":"\/Date(1234656000000)\/"}
     
      string javascriptJson = JsonConvert.SerializeObject(entry, new JavaScriptDateTimeConverter());
      // {"Details":"Application started.","LogDate":new Date(1234656000000)}
     
      string isoJson = JsonConvert.SerializeObject(entry, new IsoDateTimeConverter());
      // {"Details":"Application started.","LogDate":"2009-02-15T00:00:00Z"}
    }
