    class ReportData
    {
        public double MonthlyAmount { get; set; }
        public double AnnualAmount { get; set; }
        public double Amount { get; set; }
    }
    ...
    
    protected double CDCost()
    {
        return new ReportData() 
            { 
                Amount = users * 14.95
                MonthlyAmount = amount, 
                AnnualAmount = amount * 12.0,
            };
    }
