            SqlConnection con = new SqlConnection(ManagementSystem.Properties.Settings.Default.manage);
            con.Open();
            SqlCommand cmd = new SqlCommand("select max (RefNo)+1 from fees", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtRegno.Text = dr[0].ToString();
                    if (txtRegno.Text=="")
                    {
                        txtRegno.Text = "1";
                    }
                }
            }
            else
            {
                txtRegno.Text = "-1";
            }
            con.Close();
      }
