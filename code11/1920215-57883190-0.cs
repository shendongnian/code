    public class Agent
    {
        public long AgentId { get; set; }
    
        public Virtual ICollection<RealEstateTransaction> ListingRealEstateTransactions { get; set; }
    
        public Virtual ICollection<RealEstateTransaction> SellingRealEstateTransactions { get; set; }
    }
    
    public class RealEstateTransaction
    {
        public long RealEstateTransactionId { get; set; }
    
        [ForeignKey("ListingAgentId")]
        public Agent ListingAgent { get; set; }
        public long ListingAgentId { get; set; }
        
    
        [ForeignKey("SellingAgentId ")]
        public Agent SellingAgent { get; set; }
        public long SellingAgentId { get; set; }
        
    }
