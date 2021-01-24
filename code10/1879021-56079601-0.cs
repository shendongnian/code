    var results = suppliers
    	.Where(i => i.DecisionIssuedOn >= selectedDecisionIssuedOn)
    	.GroupBy(i => i.Decision)
    	.Select(group => new
    	{
    		Decision = group.Key,
    		TotalAmount = group.Sum(g => g.Amount),
    		SupplierCount = group.Select(i => i.SupplierNo).Distinct().Count()
    	});
