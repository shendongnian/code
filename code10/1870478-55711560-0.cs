    static void DoStuffToCustomers(List<int> customerIds)
    {
        using (var db = new Db())
        using (var tran = db.Database.BeginTransaction())
        {
            foreach (var id in customerIds)
            {
                db.DoStuffToCustomer(id);
            }
            db.SaveChanges();
            tran.Commit();
        }
    }
