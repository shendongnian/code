    using (SqlConnection cn = new SqlConnection(connectionString)) 
    {    
      using (SqlCommand cmd = new SqlCommand("DELETE FROM data WHERE item ='" +  listBox1.SelectedItem + "'", cn);
      {
        cn.Open();
        cmd.ExecuteNonQuery();
      }
    }
