    public class Event
    {
        public int eventId { get; set; }
        public string eventName { get; set; }
        public string startDateTime { get; set; }
        public string endDateTime { get; set; }
    }
    
    public class RootObject
    {
        public List<Event> events { get; set; }
        public object autostartEvent { get; set; }
    }
