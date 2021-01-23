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
                           // read here
                        }
                    }
                } 
                connection.Close()
            }`
