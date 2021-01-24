    public class Subscription
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
