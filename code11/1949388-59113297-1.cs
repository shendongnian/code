    public object getInfo(string infoReq, string username)
    {
        string query = "select @infoReq from AccountDB where username like '%@username%'";
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@infoReq", infoReq);
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
        catch (Exception e){
        }
        return MessageBox.Show("Please check your fields");
    }
