    public abstract class ContractParticipant
    {
        public int Id { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<Contract> SellerContracts { get; set; }
        [InverseProperty("Buyer")]
        public virtual ICollection<Contract> BuyerContracts { get; set; }
    }
    public class Supplier : ContractParticipant
    {
        <...other properties here...>
    }
    
    public class Dealer : ContractParticipant
    {
        <...other properties here...>
    }
    
    public class Retailer : ContractParticipant
    {
        <...other properties here...>
    }
    public class Contract
    {
        public int Id { get; set; }
        public virtual ContractParticipant Seller { get; set; }
        public virtual ContractParticipant Buyer { get; set; }
    }
