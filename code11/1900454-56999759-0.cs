    public class Agreement
    {
        public int Id { get; set; }
        public Guid? BuyerId { get; set; }
        public Guid? SellerId { get; set; }
        public int AgreementIdForBuyer { get; set; }
        public Guid OwnerActorIdForBuyer { get; set; }
        public int AgreementIdForSeller { get; set; }
        public Guid OwnerActorIdForSeller { get; set; }
    
        public AgreementInfo ByerAgreementInfo { get; set; }
        public AgreementInfo SellerAgreementInfo { get; set; }
    }
