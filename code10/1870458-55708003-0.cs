    using (TransactionScope transaction = new TransactionScope())
    {
    
        using (var context = new FMDataContext())
        {            
            context.ExecuteCommand("Update Table1 set X = 1 Where Y = 2");
            context.ExecuteCommand("Update Table2 set X = 3 Where Y = 4");
        }
        transaction.Complete();
    }
