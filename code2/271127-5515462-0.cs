    var resuts =                 (from acc in dc.Accounts
                                 join purchase in dc.Purchases on 
                                 acc.ID equals purchase.AccountID
                                 select new {Account = acc, Purchase = purchase}).ToList();
    
    
    daysVal30 = results.Where(x=>(DateTime.Now - x.Purchase.Timestamp).Days <= 30).Sum(x=>x.Purchase.Value);
    daysVal60 = results.Where(x=>(DateTime.Now - x.Purchase.Timestamp).Days > 30 && (DateTime.Now - x.Purchase.Timestamp).Days <=60).Sum(x=>x.Purchase.Purchase.Value);
    
    grid.DataSource = results;
