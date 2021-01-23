           string connection = @"Data Source=.\SQLEXPRESS;Database=TestDatabase;Integrated Security=True";
            LinqToSQLDataContext dc = new LinqToSQLDataContext(connection);
            if (!dc.DatabaseExists())
            {
                dc.CreateDatabase();
            }
