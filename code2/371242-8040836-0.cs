    public class Contract
    {
        public int Id { get; set; }
        public virtual Seller Sellers { get; set; }
        public virtual Buyer Buyers { get; set; }
    }
