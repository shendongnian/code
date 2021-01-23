    using (SqlConnection con = new SqlConnection(dc.Con))
    {
        using (SqlCommand cmd = new SqlCommand("SP_ADD", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
            cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
            con.Open();
            cmd.ExecuteNonQuery();
        }            
    }
