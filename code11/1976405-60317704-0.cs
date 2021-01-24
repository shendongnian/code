    public class Body
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Format { get; set; }
    }
    
    public class Event
    {
        public string Id { get; set; }
        public Body Body { get; set; }
        public object BodyProperties { get; set; }
        public string EventType { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    
    public class RootObject
    {
        public List<Event> Events { get; set; }
    }
