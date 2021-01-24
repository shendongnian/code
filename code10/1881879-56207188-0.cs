    public class Event
    {
        //.. the rest of your attributes here
        public EventParameters Parameters { get; set; }
    }
    public class EventParameters
    {
        public int? Age { get; set; } // If such parameter may not exist in your JSON, ensure it to be nullable in your POCO.
        public string Country { get; set; }
        public string Gender { get; set; }
    }
