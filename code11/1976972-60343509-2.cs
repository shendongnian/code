        string connectionString = @"data source=MS-KIRON-01;initial catalog=MSTestDB;integrated security=True;MultipleActiveResultSets=True";
        var columns = new List<string>();  // List<string> pTypes;
        using (var con = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand("SELECT Username, Email FROM TestTable", con);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {   ///code works up to this point
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {   // breakpoint here shows the 4 columns... 
                        var obj = new UserModel();
                        if (reader["Username"] != DBNull.Value)
                            obj.Username = reader["Username"].ToString();
                        if (reader["Email"] != DBNull.Value)
                            obj.Email = reader["Email"].ToString();
                        columns.Add(obj.Username);
                        columns.Add(obj.Email);
                    }
                }
           
                reader.Close();
            }
            con.Close();
        }
        return columns.ToArray();
