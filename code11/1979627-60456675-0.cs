    FormsAuthentication.Initialize();
    string roles = string.Empty;
    var conn = @"Data Source = localhost;Initial Catalog=web"; // Here your problem
    
    using (var con = new SqlConnection(conn))
    {
        using (SqlCommand cmd = new SqlCommand("Get_User_Role"))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", btnLogin);
    
            cmd.Connection = con;
    
            con.Open();
    
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            roles = reader["Roles"].ToString();
            con.Close();
        }
    }
