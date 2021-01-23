    using (SqlConnection dataConn = new SqlConnection(ConnectionString))
            {
                dataConn.Open();
                using (SqlCommand dataCommand = dataConn.CreateCommand())
                {
                    dataCommand.CommandType = CommandType.StoredProcedure;
                    dataCommand.CommandText = "InsertData";
                   
                    dataCommand.Parameters.AddWithValue("@QuoteNumber", quote); 
                    dataCommand.Parameters.AddWithValue("@ItemNumber", item); 
                    dataCommand.ExecuteNonQuery();
                }
            }
