    protected void btsubmit_Click(object sender, EventArgs e)
        {  
        string constr = ConfigurationManager.ConnectionStrings["remCoString"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
    
        SqlCommand cmd = new SqlCommand("SELECT Username, Password from login where Username='" + usertxt.Text + "' and Password = '" + passtxt.Text + "'", conn);
         cmd.Parameters.AddWithValue("@Username", usertxt.Text);
         cmd.Parameters.AddWithValue("@Password", passtxt.Text);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         da.Fill(dt);
         if (dt.Rows.Count > 0)
         {
            
             Response.Redirect("Details.aspx");
         }
         else
         {
    
             msg.Text = "user name and password are wrong";
             
         }
        conn.Close();
        }
