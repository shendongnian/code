    using (var db = new MyDataContext())
    {
        db.Connection.Open();
        using (var ts = new TransactionScope())
        {
            // whatever you need to do
            db.SaveChanges();
            ts.Complete();
        }
        db.Connection.Close();
    }
