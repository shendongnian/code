    void ExecuteCommand(string sql)
    {
               SqlCommand cmd = new SqlCommand(sql);  
                cmd.ExecuteNonQuery();
                ConnectionClass.CloseConnection();
    }
