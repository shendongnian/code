    protected void Login_Click(object sender, EventArgs e)
    {
     SqlConnection con = new SqlConnection("Data Source=SYSTEM1;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        string sql;
        sql = "select *from user1 where uname ='" + TextBox1.Text + "' and pwd = '" + TextBox2.Text + "'";
        cmd.CommandText = sql;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Redirect("User.aspx");
        }
    }
