            SqlCommand selectuser = new SqlCommand("select username,password from users where username = '" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'", badersql);
            SqlDataReader dr = null;
            try
            {
                dr = selectuser.ExecuteReader();
                Label1.Visible = !dr.Read();
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
