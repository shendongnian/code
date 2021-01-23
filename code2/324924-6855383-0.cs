    string password=string.Empty;
    using(SqlConnection con = new SqlConnection("Data Source=xxxx-pc\\ddd;Initial Catalog=db_Login;User Id=sd;Password=ds;"))
    {
        using(SqlCommand com = new SqlCommand("select password from tab_userinformation where Username=@p1", con))
        {
            com.Parameters.AddWithValue("@p1",txt_uname.Text);
            con.Open();
            object retValue=com.ExecuteScalar();
            if(retValue!=null)
            {
                password=retValue.ToString();
            }
            con.Close();
        }
    }
    
    if (!string.IsNullOrEmpty(password))
    {
        if (password== txt_pwd.Text)
        {
            Session["user"] = txt_uname.Text;
            Response.Redirect("default_Page.aspx");
        }
            
    }
