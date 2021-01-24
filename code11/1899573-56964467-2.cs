          using (SqlConnection con = new SqlConnection(connectionString))
         {
    	     var command = new SqlCommand("SELECT dbo.RoomAvailability()", con);
    	     con.Open();
    	     int returnValue = (int)command.ExecuteScalar();
    	     
    	     Console.WriteLine(returnValue.ToString());
         }
    
