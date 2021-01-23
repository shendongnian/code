    public STPCompany SponsorOrBankFacingBorrowerCompany
    {
        get
        {
            if (STPData == null)
            {
                throw new InvalidOperationException("'STPData' is null");
            }
            if (STPData.AffiliateTradeIndicator == null)
            {
                throw new InvalidOperationException(
                    "'STPData.AffiliateTradeIndicator' is null");
            }
            if (STPData.AffiliateTradeIndicator.Value == null)
            {
                throw new InvalidOperationException(
                    "'STPData.AffiliateTradeIndicator.Value' is null");                ;
            }
            if (STPData.AffiliateTradeIndicator.Value)
            {
                return BankFacingBorrower;
            }
            else
            {
                return Sponsor;
            }
        }
    }
