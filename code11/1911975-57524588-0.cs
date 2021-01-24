    [DynamoDBTable("Events")]
    public class Event
    {
        [DynamoDBHashKey]   
        public int EventId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsAlcoholAllowed { get; set; }
        public string Description { get; set; }        
        public bool IsDeleted { get; set; }
    }
