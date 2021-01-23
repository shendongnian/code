    using (var con = new SqlConnection(...))
    {
        con.Open();
        using (var tran = con.BeginTransaction())
        {
            using (var db = new YourDataContext(con))
            {
                // This line is needed in .NET 3.5 (not in 4.0)
                db.Transaction = tran;
                // Do your stuff
                db.SubmitChanges();
                // Do more stuff
                db.SubmitChanges();
            }
        }
    }
