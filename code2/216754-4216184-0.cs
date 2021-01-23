    var list = (from c in Transactions() 
               group c by c.StoreID into g 
               select new TransactionDetail{  
                   Description = g.FirstOrDefault().Descrip, 
                   BusinessName = g.FirstOrDefault().BusinessName, 
                   TransactionAmount = g.Where(cr => cr.EntryType == cnCommon.INSERT_ENTRY).Sum(cr=>cr.TransactionAmount).Value, 
                   PurchasesRequired = g.FirstOrDefault().PurchasesNeeded  
                    }).ToList(); 
