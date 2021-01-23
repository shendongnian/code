        try
            {
    
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetItem", conn))
                    {
                        command.Paramaters.AddWithValue("@ID",ID);
                        command.CommandType = CommandType.StoredProcedure;
    
                        conn.Open();
    
                        reader = command.ExecuteReader();
    
                        while (reader.Read())
                        {
                           
                // 
                                ret = this.Convert(reader);
                           
                        }
    
                    }
                }
            }
            catch (Exception ex)
            {
    
            }  
