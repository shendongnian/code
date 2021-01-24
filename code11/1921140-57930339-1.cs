    class ViewModel
    {
      public DataTable GridSource { get; set; }
    
      public ViewModel()
      {
        // Create a data set with an arbitrary column and row count
        this.GridSource = new DataTable();
    
        // Create column headers with alphabetic letters from 'A' to 'G'. 
        // The decimal ASCII value is converted to a string.
        for (var asciiCode = 65; asciiCode < 72; asciiCode++)
        {
          this.GridSource.Columns.Add(new DataColumn(new string((char) asciiCode, 1), typeof(CellDataModel)));
        }
    
        // Populate data table
        int maxNumberOfRows = 5;
        for (var rowNumber = 1; rowNumber <= maxNumberOfRows; rowNumber++)
        {
          DataRow newRow = this.CellTable.NewRow();
          foreach (DataColumn tableColumn in this.CellTable.Columns)
          {
            newRow[tableColumn.ColumnName] = new CellDataModel($"Value: {rowNumber}{tableColumn.ColumnName}");
          }
    
          this.GridSource.Rows.Add(newRow);
        }
      }
    }
