    using(SqlCommand cmd  = new SqlCommand("Select * from Table1 where Id = @id and Column2=@columnTwo", myConnection))
    {
       cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt)).Value = someId;
       cmd.Parameters.Add(new SqlParameter("@columnTwo", SqlDbType.NVarChar)).Value = "You name it";
       //..
    }
