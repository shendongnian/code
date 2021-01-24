        string sessionvariable;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            sessionvariable = Session["primaryKey"].ToString();
            string query = "update manager set address=@address,permanantaddress=@permanantaddress,mno=@mno where managerid=@managerid";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@address", txtadd.Text);
            cmd.Parameters.AddWithValue("@permanantaddress", txtperaddress.Text);
            cmd.Parameters.AddWithValue("@mno", txtmno.Text);
            cn.Open();
            if (sessionvariable != null)
            {  
                **here give an error System.Data.SqlClient.SqlException: Must declare the scalar variable "@managerid"**
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
