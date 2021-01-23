    ....
    StringBuilder ticket = new StringBuilder();
    
    using (var reader = command.ExecuteReader())
    {
    	while (reader.Read())
    	{
    		 i++;
    
    			if (!reader.IsDBNull(reader.GetOrdinal("r.TICKET")))
    			{
    				ticket.Append(reader.GetString(reader.GetOrdinal("r.TICKET")));
    				// Some process
    			}
    		}
    	}
    	
    	// Write the ticket content to a file
    	using(StreamWriter sw = new StreamWriter("ticket.txt"))
    	{
    		sw.WriteLine(ticket.ToString());
    	}
    }
