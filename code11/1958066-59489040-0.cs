      public void disp_data()
       {
          con.Open();
          SqlCommand cmd = con.CreateCommand();
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = "Your Query here";
          cmd.ExecuteNonQuery();
          DataTable dt = new DataTable();
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(dt);
          dataGridView1.DataSource = dt;
          con.Close();
        }
