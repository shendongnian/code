    public class Account
    {
        public int AccountId { get; set; }                
    
        [Column(TypeName="money")]
        public decimal Amount { get; set; }
    }
