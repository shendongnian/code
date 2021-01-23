    using (SqlConnection conn = new SqlConnection("connection string here"))
    using (SqlCommand cmd = new SqlCommand("sql query", conn))
    {
        // execute it blah blah
    }
