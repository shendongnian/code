    Table table = new Table();
    table.GridLines = GridLines.None;
    table.CellPadding = 3;
    table.CellSpacing = 0;
    // add a header
    TableHeaderRow header = new TableHeaderRow();
    foreach (string header in new string[] { "column1", "column2" }) {
        TableCell cell = new TableCell();
        cell.Text = header;
        header.Cells.Add(cell);
    }
    // add data
    foreach (var rowd in data) {
        TableRow row = new TableRow();
        foreach (string columnData in new string[] { rowd.Column1, rowd.Column2 }){
            TableCell cell = new TableCell();
            cell.Text = columnData;
            row.Cells.Add(cell);
        }
        table.Rows.Add(row);
    }
