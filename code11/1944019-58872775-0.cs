c#
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter sda;
        public SqlDataReader sdr;
        public DataSet ds = new DataSet();
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
Then the signIn method:
c#
protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string Query = "select * from table where Email='" + txtEmail.Value + "' and Password='" + txtPassword.Value + "'";
            if (ConnC.IsExist(Query))
            {
                string UserName = ConnC.GetColumnVal(Query, "UserName");
                Session["UserName"] = UserName;
                Session["Email"] = txtEmail.Value;
                Response.Redirect("someaspxpage.aspx");
            }
            else
                txtEmail.Value = "Invalid Email or Password!!";
        }
Where your IsExist() returns `true` if(hasRows):
c#
public bool IsExist(string Query)
        {
            bool check = false;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    check = true;
            }
            sdr.Close();
            con.Close();
            return check;
        }
