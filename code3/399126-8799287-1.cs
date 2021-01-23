        using(SqlConnection  connection = new SqlConnection("ConnString"))
        {
           connection.Open();
           SqlCommand comm = new SqlCommand("insert into table_name(col_name) values (@value)",connection);
           comm.Parameters.AddWithValue("@value",theValue);
           comm.ExecuteNonQuery();
        }
