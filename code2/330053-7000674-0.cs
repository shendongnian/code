    string query_sl = "select sum(amount) as amount from sale where cusid = @CUSID and invdate < @MAXDATE group by cusid"; 
    using(SqlCommand cmd = new SqlCommand(query_sl, c))
    {
        cmd.Parameters.Add(new SqlParameter("@CUSID", SqlDbType.Int)).Value = cus_id;
        cmd.Parameters.Add(new SqlParameter("@MAXDATE", SqlDbType.DateTime)).Value = maxdate;
        ...
    }
