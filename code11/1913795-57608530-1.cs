    public class Event 
    {
            public int Id { get; set; }
    
            public string Subject { get; set; }
    
            public string Location { get; set; }
    
            [JsonProperty("start_time")]
            public DateTime StartTime { get; set; }
    
            [JsonProperty("end_time")]
            public DateTime EndTime { get; set; }
    
            [JsonProperty("all_day_event")]
            public bool AllDayEvent { get; set; }
    
            [JsonProperty("calendar_id")]
            public int CalendarId { get; set; }
        }
