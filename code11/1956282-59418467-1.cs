	var expenseCollection = importedData
		.GroupBy(x => new { x.EmployeeName, x.CustomerName })
		.Select
		(
			y => new Expense
			{
				EmployeeName = y.Key.EmployeeName,
				CustomerName = y.Key.CustomerName,
				LineItems = y.Select
				(
					item => new ExpenseLineItem
					{
						ExpenseDate = item.ExpenseDate,
						Amount = item.Amount,
						Description = item.Description
					}
				).ToList()
			}
		);
