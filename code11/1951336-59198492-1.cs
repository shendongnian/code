C#
testDK.ForEach(s => s.TotalSalesDK = s.TotalSales);
testSE.ForEach(s => s.TotalSalesSE = s.TotalSales);
testDK.Concat(testSE)
   .GroupBy(s => s.VariantId)
   .Select(g => new SaleNumber() { 
      VariantId = g.First().VariantId,
      ProductId=g.First().ProductId,
      TotalSales = g.Sum(s=>s.TotalSalesDK) + g.Sum(s=>s.TotalSalesSE),
      TotalSalesDK=g.Sum(s=>s.TotalSalesDK),
      TotalSalesSE=g.Sum(s=>s.TotalSalesSE)
   }).ToList()
