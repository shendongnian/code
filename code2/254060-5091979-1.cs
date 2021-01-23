    public static void ExecuteNonQuery(string sql, SqlConnection connection) 
    {     
        using(var cmd = new SqlCommand(sql, con))
        {         
            cmd.ExecuteNonQuery();     
        }     
    }
