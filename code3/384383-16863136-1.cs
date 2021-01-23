    int GetLastUsedRow(ExcelWorksheet sheet) {
        var row = sheet.Dimension.End.Row;
        while(row >= 1) {
            var range = sheet.Cells[row, 1, row, sheet.Dimension.End.Column];
            if(range.Any(c => !string.IsNullOrEmpty(c.Text))) {
                break;
            }
            row--;
        }
        return row;
    }
