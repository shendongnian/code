    using (SqlCommand cmd  = new SqlCommand("InsertData", conn))
    {
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(new SqlParameter("@QuoteNumber ", QuoteNumber ));
       cmd.Parameters.Add(new SqlParameter("@ItemNumber ", ItemNumber ));
       cmd.ExecuteNonQuery();
    }
