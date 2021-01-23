    private DateTime recruitmentDate;    
    public DateTime RecruitmentDate
    {
        get { return recruitmentDate; }
        set
        {
            validate(value);
            recruitmentDate = value;
        }
    }
