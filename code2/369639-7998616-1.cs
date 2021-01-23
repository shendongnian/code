           while (reader.Read())
           {
               if (!reader.IsDBNull("TopID"))
               {
                  topID = Convert.ToInt32(reader["TopID"]);
               }
           }
