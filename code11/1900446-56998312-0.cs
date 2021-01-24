    public class Agreement
    {
        ...
    
        [ForeignKey("ByerAgreementInfo ")]
        public int ByerAgreementInfoId { get; set; }
        public AgreementInfo ByerAgreementInfo { get; set; }
    
        [ForeignKey("SellerAgreementInfo ")]
        public int SellerAgreementInfoId { get; set; }
        public AgreementInfo SellerAgreementInfo { get; set; 
    }
