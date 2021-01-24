ALTER TABLE [tbladminclient]
ADD CONSTRAINT df_UserType
DEFAULT 'User' FOR UserType; //whenever you insert then Bydefault Entry is User: 
how to identify user is client or admin
Code:
User LogIn
c#
        protected void Button1_Click(object sender, EventArgs e)
        {
            string emailid = txtemailId.Text;
            string password = txtPassword.Text;
            Client_Login(emailid,password);
        }
        void Client_Login(string emailid,string password)
        {
            string conn = ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlConnection cn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("select * from tbladminclient where EmailId=@EmailId and Password=@Password", cn);
            cn.Open();
            cmd.Parameters.AddWithValue("@EmailId", emailid);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader dr = cmd.ExecuteReader(); //data read from the database 
            if (dr.HasRows == true)//HasRows means one or more row read from the database
            {
                if (dr.Read())
                {
                    if (dr["UserType"].ToString() == "User")
                    {
                        Response.Write("successfully Client Login");
                    }
                    else
                    {
                        Response.Write("Not successfully Client Login");
                    }
                }
            }
            else
            {
                Response.Write("Not Found");
            }
            cn.Close();
        }
Admin LogIn
c#
  protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = txtEmailId.Text;
            string Password = txtUserPassword.Text;
            Login_Click(userName, Password);
        }
        void Login_Click(string emailid, string Password/*string UserType*/)
        {
            string conn = ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlConnection cn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("select * from tbladminclient where EmailId=@EmailId and Password=@Password", cn);
            cn.Open();
            cmd.Parameters.AddWithValue("@EmailId", emailid);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader dr = cmd.ExecuteReader(); //data read from the database 
            if (dr.HasRows == true)//HasRows means one or more row read from the database
            {
                if (dr.Read())
                {
                    if (dr["UserType"].ToString() == "admin")
                    {
                        Response.Write("Successfully Admin Login");
                    }
                    else
                    {
                        Response.Write("Not successfully Admin Login");
                    }
                }
            }
            else
            {
                Response.Write("Not Found");
            }
            cn.Close();
        }
