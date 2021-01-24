    string sql = @"update stock_over_time set product_qty = product_qty - @qty, date_changed = @date where product_name = @pname";
    using (SqlConnection connection = new SqlConnection(connString)
    {
      connection.Open();
      using (SqlCommand cmd= new SqlCommand(sql, connection))
      {
         md.Parameters.Add("@qty", SqlDbType.SqlInt32).value = qty;  
         cmd.Parameters.Add("@date", SqlDbType.SqlDateTime).value =  date;
         cmd.Parameters.Add("@pname", SqlDbType.Varchar, 50).value = pname;
         cmd.ExecuteNonQuery();
      }
    }
