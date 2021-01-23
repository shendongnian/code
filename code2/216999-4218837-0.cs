    using (SqlDataAdapter adapter = new SqlDataAdapter())
    using (SqlCommand command = new SqlCommand("selCompanies", sqlConn))
    {
        command.CommandType = CommandType.StoredProcedure;
        //...snip...
    }
