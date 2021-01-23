    using (IDataReader reader = SqlHelper.ExecuteReader(_connectionString, "dbo.GetOrders"))
            {
               if(reader.HasRows==false)
              {
                 Response.Write("EOF"); // empty
              }
    
                while (reader.Read()) //read only registers
                {
                    yield return FillRecord<Order>(reader, StringComparer.OrdinalIgnoreCase);
                }
                reader.Close();
            }
    }
