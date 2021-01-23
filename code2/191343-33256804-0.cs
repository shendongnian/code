    using (SqlConnection con = new SqlConnection(Connection_String))
    {
       SqlCommand cmd = new SqlCommand("select * from Customers", con);
       cmd.CommandType = CommandType.StoredProcedure;
       SqlDataReader adpt = cmd.ExecureReader();
       if(rdr.Read())
        {
          lblName.Text = rdr[0].ToString();
        }
     }
