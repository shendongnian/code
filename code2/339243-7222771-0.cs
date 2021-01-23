    using (sqlCon = new SqlConnection(connectionString))
    {
        if (sqlCon.State == ConnectionState.Open)
        {
            ....
        }
    }
