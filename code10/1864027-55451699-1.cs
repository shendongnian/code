    public class Consumer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
    
    public class EventData
    {
        public string id { get; set; }
        public string language { get; set; }
        public int stars { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string referenceId { get; set; }
        public DateTime createdAt { get; set; }
        public string link { get; set; }
        public Consumer consumer { get; set; }
    }
    
    public class Event
    {
        public string eventName { get; set; }
        public string version { get; set; }
        public EventData eventData { get; set; }
    }
    
    public class RootObject
    {
        public List<Event> events { get; set; }
    }
