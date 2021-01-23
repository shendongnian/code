    private void GenerateTable()
    
        {
    
            DataTable dt = CreateDataTable();
    
            Table table = new Table();
    
            TableRow row = null;
    
     
    
            //Add the Headers
    
            row = new TableRow();
    
            for (int j = 0; j < dt.Columns.Count; j++)
    
            {
    
                TableHeaderCell headerCell = new TableHeaderCell();
    
                headerCell.Text = dt.Columns[j].ColumnName;
    
                row.Cells.Add(headerCell);
    
            }
    
            table.Rows.Add(row);
    
     
    
            //Add the Column values
    
            for (int i = 0; i < dt.Rows.Count; i++)
    
            {
    
                row = new TableRow();
    
                for (int j = 0; j < dt.Columns.Count; j++)
    
                {
    
                    TableCell cell = new TableCell();
    
                    cell.Text = dt.Rows[i][j].ToString();
    
                    row.Cells.Add(cell);
    
                }
    
                // Add the TableRow to the Table
    
                table.Rows.Add(row);
    
            }
    
            // Add the the Table in the Form
    
            form1.Controls.Add(table);
    
        }
