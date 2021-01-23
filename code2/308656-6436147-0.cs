    [WebMethod]  
    public Boolean UserNameExists(String userName)  
    {   
        SqlConnection conn = 
            new SqlConnection("Data Source=.\\SQLEXPRESS;
                Initial Catalog=User;Integrated Security=True");   
        SqlCommand dbCommand = new SqlCommand();  
        dbCommand.CommandText = 
            @"SELECT COUNT(*) 
            FROM User 
            WHERE UserName='" + userName + "'";
        // this textusername is from the window form  
        dbCommand.Connection = conn;  
        conn.Open();
        int matchesCount = int.Parse(dbCommand.ExecuteScalar());
        conn.Close();  
        return matchesCount != 0;
    
    }
