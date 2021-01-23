    using (var conn = new SqlConnection(connectionString))
    { 
        using (var tx = conn.BeginTransaction())
        {
            FirstMethod(conn);
            SecondMethod(conn);
            tx.Commit();
        }
    }
