    public salespersonFigures(string name, decimal sales)
    {
          salesperson = name;
          weeklySales = sales;
          // initialize pay and commission
          pay = 0m;
          commission = 0m;
          commission = GetCommission(sales);
          pay = WEEKLY_BASE SALARY + commission;
    }
