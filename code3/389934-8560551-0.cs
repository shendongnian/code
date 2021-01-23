    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            string uname = "";
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            TextBox txtbox1_val = (TextBox)row.FindControl("TxtChangeActive");
            uname = Server.HtmlDecode(row.Cells[1].Text.ToString());
            string upd_query = "update login set active='" + txtbox1_val.Text + "' where uname='" + uname + "' ";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(upd_query, con);
            cmd.ExecuteNonQuery();
            string query_login = "select * from Login";
            SqlDataAdapter da_login = new SqlDataAdapter(query_login, con);
            DataSet ds_login = new DataSet();
            da_login.Fill(ds_login);
            GridView1.DataSource = ds_login;
            GridView1.DataBind();
        }
    }
     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    }
