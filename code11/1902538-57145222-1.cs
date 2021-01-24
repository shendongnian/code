     Dictionary<int, string> col_values = new Dictionary<int, string>();
             
     using (OracleDataReader reader = cmd.ExecuteReader())
     {
          for (int i = 0; i < reader.FieldCount; i++)
          {
              //First add indexes to Dictionary 
              // I add column names here - didn't test for string.Empty !!
              col_values.Add(i, string.Empty);
          }
            
          //Then read row by row and modify Dictionary - If text is larger than string.Empty
          //Dictionary must be .ToArray(), or else you'll have an error for modifying collection
          while (reader.Read())
          {
              foreach (var item in col_values.ToArray())
              {
                 string rdr_text = reader[item.Key].ToString().Trim()??string.Empty;
                             
                 if (item.Value.Length<rdr_text.Length)
                 {
                     col_values[item.Key] = rdr_text;
                 }
              }
          }
                  
          foreach (var item in col_values)
          {
             //...And here we have all longest strings stored, for each column...Job done
          }
     }
