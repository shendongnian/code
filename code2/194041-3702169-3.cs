    var proposedPayments = new List<LineItem>();
    decimal cashOnHand = ...;
    var query = invoices.SelectMany(iv => iv.LineItems)
                        .GroupBy(li => li.Priority)
                        .SelectMany(gg =>
                             gg.OrderBy(li => li.DueDate)
                               .Select((li,idx) => Tuple.Create(idx, gg.Key, li)))
                        .OrderBy(tt => tt.Item1)
                        .ThenBy(tt => tt.Item2)
                        .Select(tt => tt.Item3);
    foreach (var item in query)
    {
        if (cashOnHand >= item.Cost)
        {
            proposedPayments.Add(item); 
            cashOnHand -= item.Cost;
        }
        if (cashOnHand == 0m) break;
    }
