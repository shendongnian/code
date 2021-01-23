    using(SqlConnection _conn = new SqlConnection(-your-connection-string-here))
    using(SqlCommand _cmd = new SqlCommand("dbo.sp_Noskheh_SumOfTotalPay", _conn))
    {  
       _cmd.CommandType = CommandType.StoredProcedure;
       _cmd.Parameters.Add(new SqlParameter("@CO_ID", SqlDbType.Int));
       _cmd.Parameters["@CO_ID"].Value = 5; // whatever value you want
       _conn.Open();
       object result = _cmd.ExecuteScalar();
       _conn.Close();
       Int64 sum = Int64.Parse(result);
    }
