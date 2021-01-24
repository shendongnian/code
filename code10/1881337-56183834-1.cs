    using (AccountingEntities ent = new AccountingEntities())
    {
        //just to read record
        var recs = ent.Payments.Where(pp => pp.PaymentId == 123);
    
        foreach (p in recs)
        {
            if (p.Status == 1)
            {
                    var someotherrecs = ent.SomeTable.Where(s => s.PaymentId == 456);
                    foreach (var rec in someotherrecs)
                    {
                        rec.Status = 2;
                    }
                    ent.SaveChanges();
    
            }
        }
    }
