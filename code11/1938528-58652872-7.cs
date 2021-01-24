    var groupedCustomerByCompanyNameOrderDate = customers.SelectMany(c => c.Orders.Select(o => new { c.CompanyName, o.OrderDate, o.Total }))
    	.GroupBy(c => new { c.CompanyName, c.OrderDate });
    
    foreach (var g in groupedCustomerByCompanyNameOrderDate)
    {
    	Console.WriteLine();
    	Console.WriteLine(g.Key.CompanyName);
    	Console.WriteLine(g.Key.OrderDate);
    	Console.WriteLine(g.Sum(o => o.Total));
    }
