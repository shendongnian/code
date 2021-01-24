    public class Trio {
        public Modification Modification { get; set; }
        public Event Event { get; set; }
        public FieldHistory FieldHistory { get; set; }
    
        public Trio (Modification modification, Event @event, FieldHistory fieldHistory)
        {
            this.Modification = modification;
            this.Event = @event;
            this.FieldHistory = fieldHistory;
        }
    }
