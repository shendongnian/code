    class MyCustomType
    {
      double AnnualAmount{get; set;}
      double MonthlyAmount{get; set;}
    }
    
    // and in your function you could go
    return new MyCustomType{ AnnualAmount = 4.5d, MonthlyAmount = 5.5d  };
