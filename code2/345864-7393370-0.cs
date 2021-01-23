    private DateTime? _ExpectedPromotionDate;
    public DateTime? ExpectedPromotionDate
    {
        get
        {
            return _ExpectedPromotionDate;
        }
        set
        {
           
                _ExpectedPromotionDate = value;
           
        }
    }
 
    Dac.Parameter(CN_ExpectedPromoDate, ExpectedPromotionDate??(object)DbNull.Value),
