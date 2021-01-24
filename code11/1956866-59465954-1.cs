    public bool Validate_User(Login lmodel, out string userRole)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Login");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", lmodel.Username);
                    cmd.Parameters.AddWithValue("@Password", lmodel.Password);
                    cmd.Connection = con;
                    con.Open();
                    userRole = cmd.ExecuteNonQuery();
                    con.Close();
                    
                    return !String.IsNullOrEmpty(userRole);
        }
    }
