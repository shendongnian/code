    protected void btn_Click_Login(object sender, EventArgs e)
    {
       string queryString = "SELECT * FROM [Users] WHERE Username='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "'";
       SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RbConnectionString"].ConnectionString);
        conn.Open();
       SqlCommand command = new SqlCommand(queryString, conn);
       SqlDataReader reader = null;
       reader = command.ExecuteReader();
       if (reader.Read())
       {
           Session["Username"] = txtUsername.Text;
           Session["Password"] = txtPassword.Text;
           Response.Redirect("main.aspx");
       }
       else
       {
           lblError.Visible = true;
           lblError.Text = "Incorrect Username/Password Combination";
       }
        conn.Close();
        
    }
