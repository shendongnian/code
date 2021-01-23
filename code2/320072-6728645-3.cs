    private DateTime? birthDate
    public DateTime? BirthDate
    {
        get
        {
            return CommonClass.GetDT(birthDate);
        }
        set
        {
            birthDate = CommonClass.GetDT(value);
        }
    }
