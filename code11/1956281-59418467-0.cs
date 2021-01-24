	var expenseCollection = importedData
		.GroupBy
		(
			x => new { x.EmployeeName, x.CustomerName },
			x => new ExpenseLineItem
			{
				ExpenseDate = x.ExpenseDate,
				Amount = x.Amount,
				Description = x.Description
			}
		)
		.Select
		(
			y => new Expense
			{
				EmployeeName = y.Key.EmployeeName,
				CustomerName = y.Key.CustomerName,
				LineItems = y.ToList()
			}
		);
