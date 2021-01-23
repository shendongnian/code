    enum BillPeriod
    {
       TwoMonth = 2,
       Quarterly = 3,
       SemiAnnually = 6,
       BiAnnually = 24
    }
    public Pair<Datetime, Datetime> BillDates(Datetime currentBillDate, BillPeriod period)
    {
       Datetime LastBill = currentBillDate.AddMonths(-1 * (int)period);
       Datetime NextBill = currentBillDate.AddMonths((int)period);
       return new Pair<Datetime,Datetime>(LastBill, NextBill);
    }
    
