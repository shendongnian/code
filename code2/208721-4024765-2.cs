    // Constructor
    public salespersonFigures(string name, decimal sales)
    {
        salesperson = name;
        weeklySales = sales;
        var tempCommission = GetCommission(sales);
        commission = tempCommission
        pay = WEEKLY_BASE_SALARY + tempCommission;
    }
