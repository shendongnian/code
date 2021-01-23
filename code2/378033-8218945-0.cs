    string sql = null;
    
    for (int i = 0; i < 10000; i++)
    {
      sql += "insert into test(id, name) value('" + i + "', '" + i + "');";
    }
    
    SqlCommand cmd = new SqlCommand(sql, conn);
    cmd.ExecuteNonQuery();
