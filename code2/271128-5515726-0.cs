    // Assuming that there is no fk keys.  Else you don't need joins.
    var Purchases = dc.Accounts
        .Join(dc.Purchases, a => a.Id, p => p.AccountId, (a,p) => new {a,p})
        .Select(p); //this is not evaluated yet
    
    var todayAnd30 = DateTime.Now.AddDays(30); //happens instantly in memory
    var todayAnd60 = DateTime.Now.AddDaye(60); //happens instantly in memory
    
    var purchases30 = Purchases.Where(p => p.Timestamp > todayAnd30); //will translate to SQL
    var purchases60 = Purchases.Where(p => p.Timestamp > todayAnd60; //will translate to SQL
    
    foreach (Purchases purch in purchases30) //purchases30 query hits database at this point
    {
       30daysval += purch.Value;
       //any other processing
    }
    
    foreach (Purchases purch in purchases60) //purchases60 query hits database at this point
    {
       60daysval += purch.Value;
       //any other processing
    }
