NorthwindDataContext db = new NorthwindDataContext();
            if (db.Connection.State == System.Data.ConnectionState.Closed)
                db.Connection.Open();
            var cmd = db.GetCommand(db.Customers.Where(p => p.ID == 1));
            cmd.CommandText = cmd.CommandText.Replace("[Customers] AS [t0]", "[Customers] AS [t0] WITH (NOLOCK)");
            var results = db.Translate<Customer>(cmd.ExecuteReader());
