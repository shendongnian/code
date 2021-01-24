    var groups = dataContext.History
        .GroupBy(a => new { a.BankName, a.AccountNo })
        .Select(x => new 
        {
            first = x.FirstOrDefault();
            lastDate = x.OrderByDescending(z => z.Date).FirstOrDefault();
        }
        .Select(x => new HistoryReportItem
        {
            AccountNo = x.first.AccountNo,
            BankName = x.first.BankName,
            IsActive = x.first.IncludeInCheck,
            LastDate = x.lastDate.Date,
            DataItemsCount = x.lastDate.CountItemsSend
        })
        .ToList();
