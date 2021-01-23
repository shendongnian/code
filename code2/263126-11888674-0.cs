        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from tbluser where username='" + txtusername + "' and passworde='" + txtpassworde + "'";
        cmd.Connection = con;
        if (con.State == ConnectionState.Closed) con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
           if (dr["username"] == txtusername.Text.Trim() && dr["passworde"] == txtpassworde)
            {
                Response.Redirect("kala.aspx");
                return;
            }
          
       }
    }
