    // Constructor
    public salespersonFigures(string name, decimal sales)
    {
        salesperson = name;
        weeklySales = sales;
        commission = GetCommission(sales);
        pay = WEEKLY_BASE_SALARY + commission;
    }
