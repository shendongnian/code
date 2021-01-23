     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
          StringBuilder sb = new StringBuilder();
          // show user details for example by get the data from db
          string query = "SELECT userId, UserName FROM Users";
          SqlConnection conn = new SqlConnection("conn string");
          SqlCommand comd = new SqlCommand(query, conn);
          conn.Open();
          using(SqlDataReader r = comd.ExecuteReader())
          {
              while(r.Read()) 
              {                 
                 sb.AppendLine(r.GetInt32(0) + ", " + r.GetString(1));                 
              }
              conn.Close();
          }
          textBox1.Text = sb.ToString();
     }
