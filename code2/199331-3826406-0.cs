    string[,] stringArray = new string[dataTable1.Rows.Count, dataTable1.Columns.Count];
    
    for (int row = 0; row < dataTable1.Rows.Count; ++row)
    {
       for (int col = 0; col < dataTable1.Columns.Count; col++)
       {
          stringArray[row, col] = dataTable1.Rows[row][col].ToString();
       }
    }
