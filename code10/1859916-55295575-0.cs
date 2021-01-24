    public class Document
    {
        public int Id { get; set; }
        public int EventsCount => Events?.Count ?? 0;
        public List<Event> Events { get; set; }
    }
    
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
