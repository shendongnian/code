    public static List<TheQFromDB> GetQ(out DateTime maxValue)
    {
        // Initialize the maxValue 
        maxValue = DateTime.MinValue;
        // The list with your objects....
        List<TheQFromDB> elements = new List<TheQFromDB>();
        using (SqlConnection connection = DBConnection.GetTheQFromDB())
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select *from PrintQueue WHERE AddedToQueue  >= DATEADD (day, -2, GetDate()) ", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Console.ForegroundColor = ConsoleColor.Yellow;
                // Console.WriteLine("{0}\t{1}\t\t\t{2}\t\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(4), reader.GetName(5));
                // Loop over the data returned by the reader
                while(reader.Read())
                {
                    // Build the current instance for the current record
                    // Do not declare this object outside the loop or your list
                    // will have the same values from the last record
                    TheQFromDB TheQ = new TheQFromDB();
                    TheQ.Id = (Int32)reader["Id"];
                    TheQ.PrinterName = (string)reader["PrinterName"];
                    TheQ.AddedToQueue = (DateTime)reader["AddedToQueue"];
                    TheQ.LastStatusUpdate = (DateTime)reader["LastStatusUpdate"];
                    // Now check if the current record is 'greater' than 
                    // a saved value from a previous record.
                    if(TheQ.LastStatusUpdate > maxValue)
                       maxValue = TheQ.LastStatusUpdate;
                    // Add the current element to the list
                    elements.Add(TheQ);
                }
                // Return to the caller.
                return elements;
            }
         }
    }
