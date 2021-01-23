    `using (SqlConnection connection = new SqlConnection("your connection string"))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * from SomeTable";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if(reader.HasRows)
                        { 
                           while(reader.Read()){
                           // assuming that we've a 1-column(Id) table 
                           int id = int.Parse(reader[0].ToString()); 
  
                           }
                        }
                    }
                } 
                connection.Close()
            }`
