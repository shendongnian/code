var querySyntax = (from product in SampleProductTable
    join sale in SampleSalesTable on product.Id equals sale.ProductId into sales
    from subSales in sales.DefaultIfEmpty()
    group subSales by new { product.Id, product.TotalSales }
    into grp
    select new
    {
        grp.Key.Id,
        TotalSales = grp.Sum(s => s.Amount) + grp.Key.TotalSales
    }).ToList();
If you have a burning desire to use method syntax for whatever reason, this equivalent LINQ query will also work:
var methodSyntax = (SampleProductTable
    .GroupJoin(SampleSalesTable, product => product.Id, sale => sale.ProductId,
        (product, sales) => new {product, sales})
    .SelectMany(s => s.sales.DefaultIfEmpty(), (s, subSales) => new {s, subSales})
    .GroupBy(ss => new {ss.s.product.Id, ss.s.product.TotalSales}, ss => ss.subSales)
    .Select(grp => new {grp.Key.Id, TotalSales = grp.Sum(s => s.Amount) + grp.Key.TotalSales})).ToList();
