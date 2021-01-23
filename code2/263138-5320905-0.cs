    using (SqlCommand cmd = new SqlCommand(query, conn))
            {
              int 123;
    
              cmd.Parameters.Add(new SqlParameter(@"Number", SqlDbType.int)).Value = 123;
              cmd.Parameters.Add(new SqlParameter(@"aDateTime", SqlDbType.DateTime)).Value = mydate;
    cmd.Parameters.Add(new SqlParameter(@"aDateTime", SqlDbType.decimal)).Value = value;
              cmd.ExecuteNonQuery();
            }
