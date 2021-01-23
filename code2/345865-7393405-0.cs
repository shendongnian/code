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
    public bool Save()
    {
        try
        {
            Dac.ExecuteNonQuery("Manpower_InsertEmployee",
                Dac.Parameter(CN_LoginId, LoginId),
                Dac.Parameter(CN_StoreId, StoreId),
                Dac.Parameter(CN_FirstName, FirstName),
                Dac.Parameter(CN_LastName, LastName),
                Dac.Parameter(CN_EeRole, EeRole),
                Dac.Parameter(CN_RoleRank, RoleRank),
                Dac.Parameter(CN_IsUpNComing, IsUpNComing),
                Dac.Parameter(CN_ExpectedPromoDate, ExpectedPromotionDate.HasValue ? ExpectedPromotionDate.Value : DBNull.Value),
                Dac.Parameter(CN_IsPotentialManager, IsPotentialManager));
            return true;
        }
        catch
        {
            //throw new Exception (String.Format("{0} {1}", ex.Message, ex.StackTrace));
            throw new Exception("There was an error during the save process.");
        }
