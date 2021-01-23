    using (var con = new SqlConnection(constr))
    {
        con.Open();
        using (var tran = 
            new con.BeginTransaction(IsolationLevel.ReadUncommitted))
        {
            using (var db = new MyDataContext(con))
            {
                // You need to set the transaction in .NET 3.5 (not in 4.0).
                db.Transaction = tran;
                // Do your stuff here.
                db.SubmitChanges();
            }
            tran.Commit();
        }
    }
