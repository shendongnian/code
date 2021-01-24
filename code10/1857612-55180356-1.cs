    try
    {
        int count = 0;
        while (reader.Read())
        {
            if (count == 0)
            {
                outputFile.WriteLine(String.Format("{0}, {1}, {2}",
                   reader.GetName(0), reader.GetName(1), reader.GetName(2)));
            }
            else
            {
                outputFile.WriteLine(String.Format("{0}, {1}, {2}",
                   reader.GetValue(0), reader.GetValue(1), reader.GetValue(2)));
            }   
            count++;         
         }
      }
