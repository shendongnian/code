    var fileName = this.OpenFileDialog1.FileName;
    var rows = System.IO.File.ReadAllLines(fileName);
    Char[] separator = new Char [] {' '};
    DataTable tbl = new DataTable(fileName);
    if (rows.Length != 0) {
        foreach (string headerCol in rows(0).Split(separator)) {
            tbl.Columns.Add(new DataColumn(headerCol));
        }
        if (rows.Length > 1) {
            for (rowIndex = 1; rowIndex < rows.Length; rowIndex++) {
                var newRow = tbl.NewRow();
                var cols = rows(rowIndex).Split(separator);
                for (colIndex = 0; colIndex < cols.Length; colIndex++) {
                    newRow(colIndex) = cols(colIndex);
                }
                tbl.Rows.Add(newRow);
            }
        }
    }
