    using (SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TestDb;Data Source=.\\SQLEXPRESS;"))
    {
        conn.Open();
        Stopwatch watch = Stopwatch.StartNew();
        EffectCatalogueDataContext db = new EffectCatalogueDataContext(conn);
        for (int i = 0; i < 100000; i++)
        {
            User u = new User();
            u.UserName = "Simon";
            u.Password = "Password";
            db.Users.InsertOnSubmit(u);
        }
        db.SubmitChanges();
        Console.WriteLine("Linq: {0}", watch.Elapsed);
    }
