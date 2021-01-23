    public bool Check(DateTime d1, DateTime d2)
    {
        DateTime StartDate = new DateTime(2011,1,1);
        DateTime EndDate = new DateTime(2011,4,4);
        return ((d1 >= StartDate && d1 <= EndDate) && (d2 >= StartDate && d2 <= EndDate));
    }
