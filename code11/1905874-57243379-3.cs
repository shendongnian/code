    var brushConverter = new BrushConverter();
    var tableBorderBrush = brushConverter.ConvertFrom("#CCCCCC");
    tableBorderBrush.Freeze();
    var headerCellBorderBrush = brushConverter.ConvertFrom("#FFFFFF");
    headerCellBorderBrush.Freeze();
    private void drawLogTable() 
    {
      Table oTable = new Table() { BorderThickness = new Thickness(1), BorderBrush = tableBorderBrush }
      // Add the header row with content,
      currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Date time"))) { BorderThickness = new Thickness(0, 1, 0, 0), BorderBrush = headerCellBorderBrush });
      currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Directory"))) { BorderThickness = new Thickness(0, 1, 0, 0), BorderBrush = headerCellBorderBrush });
      currentRow.Cells.Add(new TableCell(new Paragraph(new Run("File"))) { BorderThickness = new Thickness(0, 1, 0, 0), BorderBrush = headerCellBorderBrush });
      // Read file and add rows
      ...
      foreach (string line in existingFoldersArray)
      {
        ...
        // Add new row
        oTable.RowGroups[0].Rows.Add(new TableRow());
        currentRow = oTable.RowGroups[0].Rows[countLines];
        ...
        
        //Add the row's cells with their borders set
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dateTime))) { BorderThickness = new Thickness(0, 0, 0, 1), BorderBrush = tableBorderBrush });
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(directory))) { BorderThickness = new Thickness(0, 0, 0, 1), BorderBrush = tableBorderBrush });
        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(file))) { BorderThickness = new Thickness(0, 0, 0, 1), BorderBrush = tableBorderBrush });
        ...
      }
      ...
    }
