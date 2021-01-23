    // Assuming that there is no fk keys.  Else you don't need joins.
    var Purchases = dc.Accounts
        .Join(dc.Purchases, a => a.Id, p => p.AccountId, (a,p) => new {a,p})
        .Select(p);
    
    double 30daysval;
    double 60daysval;
    foreach (Purchases purch in Purchases)
    {
        TimeSpan span = DateTime.Now - purch.Timestamp;
        if (span.Days <= 30)
        {
            30daysval += purch.Value;
            //Add a row to the grid
        }
        else if (span.Days <= 60)
        {
            60daysval += purch.Value
            //Add a row to the grid
        }
    }
