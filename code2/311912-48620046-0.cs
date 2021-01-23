       protected void btn_PasswordChange(object sender, EventArgs e)
        {
            string constring = DataAccess.GetConnection();
            SqlConnection con = new `SqlConnection`(constring);
           
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
            }
            string str = "select * from tbl_MemberLogin where Password='" + txtoldpwd.Text + "'";
            DataTable DT = new DataTable();
            DT = objdut.GetDataTable(str);
            if (DT.Rows.Count == 0)
            {
                lblmsg.Text = "Invalid current password";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update tbl_MemberLogin set Password='" + txtnewpwd.Text + "' where UserName='" + Session["UserName"].ToString() + "'";
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Password changed successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
        }
