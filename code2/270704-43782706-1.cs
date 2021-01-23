     using (SqlDataReader reader = command.ExecuteReader())
     {
         while (reader.Read())
         {
             int count = reader.VisibleFieldCount;
             Console.WriteLine(count);
         }
     }
