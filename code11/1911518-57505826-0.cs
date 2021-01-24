    public class PolicyMapping
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid PolicyAId { get; set; }      
        public Policy PolicyA { get; set; }
        public Guid PolicyBId { get; set; }
        public Policy PolicyB { get; set; }
        
        public Guid BankId { get; set; }
        public Lookup_Bank Bank { get; set; }
    }
