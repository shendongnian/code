    public class Trio {
        public Modification Modification { get; set; }
        public FieldHistory FieldHistory { get; set; }
        public Event Event { get; set; }
           
        public Trio (Modification modification, FieldHistory fieldHistory, Event @event)
        {
            this.Modification = modification; 
            this.FieldHistory = fieldHistory;
            this.Event = @event;
        }
    }
