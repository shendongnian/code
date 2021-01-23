        List<CustData> myList = GetCustData();
        var query = myList
            .GroupBy(c => c.CustId)
            .Select(g => new {
                CustId = g.Key,
                Jan = g.Where(c => c.OrderDate.Month == 1).Sum(c => c.Qty),
                Feb = g.Where(c => c.OrderDate.Month == 2).Sum(c => c.Qty),
                March = g.Where(c => c.OrderDate.Month == 3).Sum(c => c.Qty)
            });
