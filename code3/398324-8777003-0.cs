    using(SqlConnection con = new SqlConnection("Data Source=MICROSOF-58B8A5\\SQL_SERVER_R2;Initial Catalog=Daniel;Integrated Security=True"))
    {
        string query = "SELECT TOP 1 Username FROM Users WHERE Username=@UserName AND Password=@Password";
    
        using (SqlCommand command = new SqlCommand(query, con))
        {
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            con.Open();
            string username = (string)command.ExecuteScalar(); //Add Null Check
            // Do stuff if username exists         
        }
    }
