    protected void SaveUser()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        
        SqlCommand cmd = new SqlCommand("INSERT_USER");
        cmd.Parameters.Add(new SqlParameter("@NAME", txtName.Text.Trim()));
        cmd.Parameters.Add(new SqlParameter("@ADDRESS", txtAddress.Text.Trim()));
        if(txtDateOfBirth.Text.Trim() != String.Empty)
            {
                cmd.Parameters.Add(new SqlParameter("@DATEOFBIRTH", txtDateOfBirth.Text.Trim()));
            }
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
    }
