    public class AgreementInfo
    {
    
        ...
    
        [InverseProperty("ByerAgreementInfo ")]
        public ICollection<Agreement> Sellers { get; set; }
        [InverseProperty("SellerAgreementInfo ")]
        public ICollection<Agreement> Buyers { get; set; }
    }
