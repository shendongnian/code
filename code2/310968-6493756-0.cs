     TableHeaderRow headerRow = new TableHeaderRow();
    
     TableHeaderCell headerTableCell1 = new TableHeaderCell();
    
     headerTableCell1.Text = "Column 1 Header";
    
     headerRow.Cells.Add(headerTableCell1);
    
     Table1.Rows.AddAt(0, headerRow);
