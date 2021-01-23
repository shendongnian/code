    using(TransactionScope trans = new TransactionScope())
    {
        using(HumanResources hr = new HumanResources())
        {
            //...
    
            hr.SaveChanges();
        }
    
        using(Inventory inv = new Inventory())
        {
            //...
    
            inv.SaveChanges();
        }
    
        trans.Complete();
    }
