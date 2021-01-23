    public class RevenueData
    {
       public decimal Revenue {get;set;}
       public string Month {get;set;}
    }
    List<RevenueData> result = data
      .Select(d => new RevenueData()
        { Revenue = Convert.ToDecimal(d["Revenue"]), Month = d["Month"] })
      .GroupBy(x => x.Month)
      .Select(g => new RevenueData()
        { Revenue = g.Sum(x => x.Revenue), Month = g.Key })
      .ToList();
