    Table table = new Table()
    //.. foreach loop through your data sourde
       TableRow row = new TableRow()
       TableCell cell = new TableCell()
    
       cell.Text = "your data element";
    
       row.Cells.Add(cell);
       table.Rows.Add(row);
    //.. close loop
    placeholderControl.Controls.Add(table);
