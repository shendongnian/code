    Excel.Range last = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell,
        Type.Missing);
    for (int row = last.Row; row > 0; row++)
    {
        Excel.Range r = (Excel.Range)sheet.Cells[row, 1];
        double o = addIn.Application.WorksheetFunction.CountA(r.EntireRow);
        if (o == 0)
            r.EntireRow.Delete();
    }
