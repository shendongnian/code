    public salespersonFigures(string name, decimal sales)
    {
          salesperson = name;
          weeklySales = sales;
          // initialize pay
          pay = 0m;
          commission = GetCommission(sales);
          pay = WEEKLY_BASE SALARY + commission;
    }
