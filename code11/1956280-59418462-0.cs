    var expenseCollection = importedData.GroupBy(x => 
        new 
        {
            x.EmployeeName,
            x.CustomerName
        })
        .Select (y => new Expense()
        {
            EmployeeName = y.Key.EmployeeName,
            CustomerName = y.Key.CustomerName,
            LineItems = y.Select(ie => new ExpenseLineItem()
            {
                ExpenseDate = ie.ExpenseDate,
                Amount = ie.Amount,
                Description = ie.Description
            }).ToList();
        });
