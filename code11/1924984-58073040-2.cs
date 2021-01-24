var groupedIncome = incomes
                 .GroupBy(inc => inc.Date.Month) //group it by month
                 .Select(groupedIncomeByMonth => 
                     new { 
                         Month = groupedIncomeByMonth.Key, 
                         Amount = groupedIncomeByMonth
                                      .Sum(monthIncome => monthIncome.Amount), 
                         IsIncome = true}) // Marker for Concat/Union All
var groupedExpenses = expenses
                    .GroupBy(exp => exp.Date.Month)
                    .Select(groupedExpenseByMonth => 
                        new { 
                            Month = groupedExpenseByMonth.Key, 
                            Amount = groupedExpenseByMonth
                                         .Sum(monthExpense => monthExpense.Amount), 
                            IsIncome = false }) // marker for Concat/Union All
var result = groupedIncome.Concat(groupedExpenses)
                  .GroupBy(x => x.Month)
                  .Select(r => 
                               new { 
                                       Month = r.Key, 
                                       Income = r.Where(p => p.IsIncome).Sum(g => g.Amount), 
                                       Expense = r.Where(p => !p.IsIncome).Sum(g => g.Amount)
                                   }).ToListAsync();
