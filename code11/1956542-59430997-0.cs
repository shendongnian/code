     while (sqlite_datareader.Read())
      {
        for (int i = 0; i < reader.FieldCount; i++)
         {
               var ColName = reader.GetName(i);
               var colValue = reader[i]; 
          }
      }
