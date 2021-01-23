        using (var sqlCon = new SqlConnection(...))
        {
            string query = @"update Organizer set Password =@password where Login=@login";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 8000);
            cmd.Parameters["@password"].Value = password;  
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 8000);
            cmd.Parameters["@login"].Value = login;  
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
       }
