    `
    try
                {
                    Excel.Worksheet excelWorksheet = workbook.ActiveSheet as Excel.Worksheet;
                    Excel.Range firstCell = excelWorksheet.get_Range("A1", Type.Missing);
                    Excel.Range lastCell = excelWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range formulaCell = excelWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeFormulas, Type.Missing);
    
                    object[,] MyFormulas;
    
                    Excel.Range worksheetCells = excelWorksheet.get_Range(firstCell, lastCell);
                    MyFormulas = formulaCell.Formula as object[,];
                    Excel.Range s;
                    foreach (var fc in formulaCell)
                    {
                        s = fc as Excel.Range;
                        string s1 = s.Formula as string;
                        int c = s.Column;
                        int r = s.Row;
    // Gives formula text and location of formula.
                    }
                }
                catch (Exception)
                {
                    ; // Throws an exception if there are no results. Probably should ignore that exception only
                }`
