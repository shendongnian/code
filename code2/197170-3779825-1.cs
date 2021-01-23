    protected void btn_Click_Login(object sender, EventArgs e)
    {
        
       SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RbConnectionString"].ConnectionString);
        conn.Open();
        string queryString = "SELECT * FROM [Users] WHERE Username=@username AND Password= @password";
       SqlCommand command = new SqlCommand(queryString, conn);
       command.Parameters.AddWithValue("@username", txtUsername.Text);
       command.Parameters.AddWithValue("@password", txtPassword.Text);
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
