    string commString = "UPDATE users SET NewPassword = @PasswordHash where Email = @Email";
    using (SqlConnection connect = new SqlConnection(constring))
    {
        using (SqlCommand comm = new SqlCommand())
        {
            comm.Connection = connect;
            comm.CommandText = commString;
            comm.Parameters.AddWithValue("PasswordHash", savedPasswordHash1);
            comm.Parameters.AddWithValue("Email", email2);
            connect.Open();
            comm.ExecuteNonQuery();
            connect.Close();
        } 
    }
