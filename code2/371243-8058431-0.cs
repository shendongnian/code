    public abstract class ContractParticipant
    {
        public virtual ICollection<Contract> Contracts { get; set; }
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
