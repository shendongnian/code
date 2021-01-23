    private Dictionary<int,Dictionary<int,string>> formulas = new Dictionary<int,Dictionary<int,string>>(); // this has to be initialized according to your formulas
    public void Recalculate()
    {
        XL.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveSheet;
        XL.Range range = worksheet.UsedRange;
        for (int iRow = 1; iRow <= arrValue.GetLength(0); iRow++)
        {
            for (int iCol = 1; iCol <= arrValue.GetLength(1); iCol++)
            {
                range.Cells[iRow, iCol].Formula = "=" + formulas[iRow][iCol];  
                range.Cells[iRow, iCol].Value = range.Cells[iRow, iCol].Value; 
            }
        }
    }
