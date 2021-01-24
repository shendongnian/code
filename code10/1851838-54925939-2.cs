    public class Event
    {
        public string Title { get; set; }
        public string DateTime { get; set; }
    }
    
    public class MonthEventsResponseModel
    {
        public Dictionary<int, List<Event>> Events { get; set; }
    }
