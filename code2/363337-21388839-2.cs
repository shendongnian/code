    using (IDataReader reader = SqlHelper.ExecuteReader(_connectionString, "dbo.GetOrders"))
        {
             if(!reader.HasRows)
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
