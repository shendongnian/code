    public class Subscription
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
