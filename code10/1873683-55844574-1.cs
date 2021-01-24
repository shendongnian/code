        using (con = new SqlConnection(constr)) {
          con.Open();
          string cmdstr = 
            $@"select userid,
                      username,
                      email,
                      eventname 
                 from [{Selectdb.Text}]"; 
          using (SqlCommand cmd = new SqlCommand(cmdstr, con)) {
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0) {
              GridView1.DataSource = dt;
              GridView1.DataBind();
            }
          } 
        }
