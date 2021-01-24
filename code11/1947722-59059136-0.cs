    public class EmailActivity
        {
            [DeserializeAs(Name = "messages")]
            public List<EmailActivityEvent> Events { get; set; }
        }
