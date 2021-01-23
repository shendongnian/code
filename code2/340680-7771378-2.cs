    public class User
    {
        [Key]
        public int Id { get; set; }
        [Include]
        [Association("User_Subscriptions", "Id","UserId")]
        // 'Id' is this classes's Id property, and 'UserId' is on Subscription
        // 'User_Subscriptions' must be unique within your domain service,
        // or you will get some odd errors when the client tries to deserialize
        // the object graph.
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
        
