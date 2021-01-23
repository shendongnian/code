    using (var db = new MyDataContext())
    {
        using (var ts = new TransactionScope())
        {
            // whatever you need to do
            db.SaveChanges();
            ts.Complete();
        }
    }
