        //TODO: validate Selectdb.Text: we don't want SQL injection, e.g.
        // Selectdb.Text = "MyTable; delete from OtherTable"
        if (!Regex.IsMatch(Selectdb.Text, "^[A-Za-z0-9_]+$")) {
          //Something wrong with Selectdb.Text - is it a real table?
        }
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
