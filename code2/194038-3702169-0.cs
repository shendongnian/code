    var proposedPayments = new List<LineItem>();
    decimal cashOnHand = ...;
    var query = from invoice in invoices
                from lineItem in invoice.LineItems
                orderby lineItem.Priority, lineItem.DueDate
                select lineItem;
    foreach (var item in query)
    {
        if (cashOnHand >= item.Cost)
        {
            proposedPayments.Add(item); 
            cashOnHand -= item.Cost;
        }
        if (cashOnHand == 0m) break;
    }
