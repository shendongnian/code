      // This is the data from the textbox 
      // hardcoded here for demonstration
      string data = "1 1 1" + Environment.NewLine 
        + "2 2 2" + Environment.NewLine 
        + "12 12 12";
      // First we need to determine the size of array dimension
      // How many rows and columns do we need
      int columnCount;
      int rowCount;
      // We get the rows by splitting on the new lines
      string[] rows = data.Split(new string[]{Environment.NewLine}, 
        StringSplitOptions.RemoveEmptyEntries);
      rowCount = rows.Length;
      // We iterate through each row to find the max number of items
      columnCount = 0;
      foreach (string row in rows)
      {
        int length = row.Split(' ').Length;
        if (length > columnCount) columnCount = length;
      }
      
      // Allocate our 2D array
      int[,] myArray = new int[rowCount, columnCount];
      // Populate the array with the data
      for (int i = 0; i < rowCount; ++i)
      {
        // Get each row of data and split the string into the
        // separate components
        string[] rowData = rows[i].Split(' ');
        for (int j = 0; j < rowData.length; ++j)
        {
          // Convert each component to an integer value and 
          // enter it into the 2D array
          int value;
          if (int.TryParse(rowData[j], out value))
          {
            myArray[i, j] = value;
          }
        }
      }
