    public List<RateArea> RateAreaList
    {
        get {
            rateAreaList = rateAreaList ?? new List<RateArea>(); 
            return rateAreaList; 
        }
        set { rateAreaList = value; }
    }
