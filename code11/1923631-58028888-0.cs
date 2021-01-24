    var groupedData = query.GroupBy(x => (x.PaymentDate ?? DateTime.UtcNow).Month)
        .Select(month =>
        {
            var weeks = Enumerable.Range(1, 4).Select(x => new productsChartDTO() { Month = month.Key, Week = x, Amount = 0 }).ToArray();
            foreach (var date in month)
            {
                int week = GetWeekNumberOfMonth(date.PaymentDate ?? DateTime.UtcNow);
                weeks[week - 1].Amount += date.Amount;
            }
            return weeks;
        })
        .SelectMany(x => x);
