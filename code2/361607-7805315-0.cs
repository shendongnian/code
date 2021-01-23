    public HoldingMap()
    {
        References(x => x.Fund, "f_id");
    }
    
    public FundMap()
    {
        HasMany(x => x._holdings)
            //.Column("fund_id")     // the default
            .Cascade.All();
    }
