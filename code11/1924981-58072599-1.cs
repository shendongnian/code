    var incomes = _context
        .Incomes
        .Where(i => i.Date.Year == year && i.UserId == id && i.IsApproved)
        .Select(i => new { Month = i.Date.Month, Income = i.Amount, Expense = 0 });
    var expenses = _context
        .Expenses
        .Where(e => e.Date.Year == year && e.UserId == id && e.IsApproved)
        .Select(e => new { Month = e.Date.Month, Income = 0, Expense = e.Amount });
    
    var summary = await incomes
        .Concat(expenses)
        .GroupBy(s => s.Month)
        .Select(g => new { Month = g.Key, Incomes = g.Sum(x => x.Income), Expenses = g.Sum(x => x.Expense) })
        .ToListAsync();
