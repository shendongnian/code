    int startRow = excelRange.Start.Row;
    int startCol = excelRange.Start.Column;
    int endRow = excelRange.End.Row;
    int endCol = excelRange.End.Column;
    
    var rowValues=(object[,]) worksheet.Cells[startRow, startCol, endRow, endCol].Value;
    List<string> lstValues = rowValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
