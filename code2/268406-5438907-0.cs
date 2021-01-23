    Func<DateTime, object> groupByClause;
    if (groupByDay) groupByClause = date => date.Date;
    else if (groupByMonth) groupByClause = date => new { date.Year, date.Month};
    else throw new NotSupportedException("Some option should be chosen");
    var result = data.Where(d => d.Type == "Deposit")
                     .GroupBy(groupByClause)
                     .Select(g => new { DateKey = g.Key,
                                        TotalDepositAmount = g.Sum(d => d.Amount),
                                        DepositCount = g.Count(),
                     });
