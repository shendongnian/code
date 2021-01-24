    int startRow = excelRange.Start.Row;
    int startCol = excelRange.Start.Column;
    int endCol = excelRange.End.Column;
    for (int i = startCol; i <= endCol; i++)
    {
        string cellText = excelRange[startRow, i].Text;
    }
