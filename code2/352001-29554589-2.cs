    private void button1_Click(object sender, EventArgs e) {
      using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd = new SqlCommand("sp_Add_contact", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
    
          cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
          cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }
