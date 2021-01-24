    using (IDbConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
    {
        con.Execute("INSERT INTO test (one, two) VALUES (@One, @Two)", new 
        {
            One = "hello",
            Two = 123
        });
    }
