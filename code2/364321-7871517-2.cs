       SqlCommand get = new SqlCommand(@"Select from IStudent where SNumber ='" + txtSnumber.Text + "'", conn); 
       SqlDataReader myReader = get.ExecuteReader();
      if (myReader.HasRows)
      {
        MessageBox.Show("ID is valid");
        while (myReader.Read())
          //Do something here        
      }
      else
        MessageBox.Show("Given ID is Invalid.");
