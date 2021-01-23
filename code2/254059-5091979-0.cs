    public static void ExecuteNonQuery(string sql) 
    {     
        using(var con = GetConnection())
        {
            con.Open();     
            using(var cmd = new SqlCommand(sql, con))
            {         
                cmd.ExecuteNonQuery();     
            }     
        }
    }
