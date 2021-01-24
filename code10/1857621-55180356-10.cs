    try
    {
        int count = 0;
        while (reader.Read())
        {
            // if this is the first row, read the column names
            if (count == 0)
            {
                outputFile.WriteLine(String.Format("{0}, {1}, {2}",
                   reader.GetName(0), reader.GetName(1), reader.GetName(2)));
            }
            
            // otherwise just the data (including 1st row)
            outputFile.WriteLine(String.Format("{0}, {1}, {2}",
               reader.GetValue(0), reader.GetValue(1), reader.GetValue(2)));
            
            count++;         
        }
    }
