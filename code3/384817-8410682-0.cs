    protected void AddRow(object sender, EventArgs e) {  
        TableRow row = new TableRow();  
        TableCell cell = new TableCell();  
        aTable.Rows.Add(row);  
        cell.Text = "Test";  
        row.Cells.Add(cell);  
        row.Cells.Add(cell);  
        row.Cells.Add(cell);  
        row.Cells.Add(cell);  
        row.Cells.Add(cell);  
        row.Cells.Add(cell);  
    }
