    public static void Merge(this ExcelRangeBase range)
    {
        ExcelCellAddress start = range.Start;
        ExcelCellAddress end = range.End;
        range.Worksheet.Cells[start.Row, start.Column, end.Row, end.Column].Merge = true;
    }
