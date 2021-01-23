    public abstract class ContractParticipant
    {
        [ForeignKey("Seller")]
        public virtual ICollection<Contract> SellerContracts { get; set; }
        [ForeignKey("Buyer")]
        public virtual ICollection<Contract> BuyerContracts { get; set; }
    }
    public class Supplier : ContractParticipant
    {
        public int Id { get; set; }
        <...other properties here...>
    }
    
    public class Dealer : ContractParticipant
    {
        public int Id { get; set; }
        <...other properties here...>
    }
    
    public class Retailer : ContractParticipant
    {
        public int Id { get; set; }
        <...other properties here...>
    }
    public class Contract
    {
        public int Id { get; set; }
        public virtual ContractParticipant Seller { get; set; }
        public virtual ContractParticipant Buyer { get; set; }
    }
