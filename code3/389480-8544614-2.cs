    // Create new CS file with Name MyClass
    public class MyClass
    {
      public string CustomerAccountName {get; set;},
        public string CustomerAccountNumber {get; set;},
          public string Code {get; set;},
          public string Name {get; set;},
          public string Profit {get; set;},
          public int QuantitySold {get; set;},
        public double  TotalCost {get; set;},
        public double TotalRevenue {get; set;},
        public double MARGIN {get; set;},
        public int SLCustomerAccountID {get; set;},
        public int SOPOrderReturnID {get; set;},
        public int SOPOrderReturnLineID {get; set;}
    }
    
    
    //
    var q = from d in cxt.K3_StockProfitMarginByCustomers
    select new MyClass()
    {
       CustomerAccountName= d.CustomerAccountName,
       CustomerAccountNumber = d.CustomerAccountNumber,
       Code = d.Code,
       Name = d.Name,
       Profile = d.Profit,
       QuantitySold= d.QuantitySold,
       TotalCost = d.TotalCost,
       TotalRevenue= d.TotalRevenue,
       MARGIN = d.MARGIN,
       SLCustomerAccountID= d.SLCustomerAccountID,
       SOPOrderReturnID= d.SOPOrderReturnID,
       SOPOrderReturnLineID= d.SOPOrderReturnLineID
    };
    
    q = q.Distinct();
    
    var l = q.ToList();
    var summary = new MyClass()
    { 
       CustomerAccountName = "",
       CustomerAccountNumber = "",
       Code = "",
       Name = "", 
       Profit = (Decimal)q.Sum(o => o.Profit),
       QuantitySold = (Decimal)q.Sum(o => o.QuantitySold),
       TotalCost= (Decimal)q.Sum(o => o.TotalCost),
       TotalRevenue= (Decimal)q.Sum(o => o.TotalRevenue),
       MARGIN = (Decimal)q.Average(o => o.MARGIN),
       SLCustomerAccountID=(String)"",
       SOPOrderReturnID=(String)"",
       SOPOrderReturnLineID=(String)""
    };
    
    l.Add(summary);
    
    return l.AsQueryable();
