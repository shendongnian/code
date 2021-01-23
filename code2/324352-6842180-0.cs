    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
      if(rdr.Read())
      {
            User user;
              
            string type = rdr.GetString(0);
            if (type == "agent")
            {
                 user = new Agent();
                 // Fill out Agent specific properties
            }
            else if( type == "client" )
            {
                 user = new Client();
                 // Fill out Client specific properties
            }
            else
            {
                 throw new InvalidProgramException ("Unknown user-type");
            }
        
            // Fill out common User properties.
        }
    }
