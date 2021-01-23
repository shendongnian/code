    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
       connection.Open(); 
       MySqlCommand command = connection.CreateCommand();
       command.CommandText = sqlQuery;
       command.CommandType = System.Data.CommandType.Text;
       // add parameters in this line
       using (MySqlDataReader reader = command.ExecuteReader())
       {  
          while (reader.Read()) 
          {     
    	     // iterate in each row
             for (int i = 0; i < reader.FieldCount; i++)
    		 {
    			// iterate each column using reader.GetValue(i)
    		 }
          }
       }
    }
