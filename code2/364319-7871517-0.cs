       SqlCommand get = new SqlCommand(@"Select from IStudent where SNumber ='" + txtSnumber.Text + "'", conn); 
       SqlDataReader myReader = get.ExecuteReader();
      if (myReader.HasRows)
      {
        Console.WriteLine("ID is valid");
        while (myReader.Read())
        Console.WriteLine("\t{0}\t{1}", myReader.GetInt32(0), myReader.GetString(1));
      }
      else
        Console.WriteLine("Given ID is Invalid.");
        
