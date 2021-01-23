    public void SetFormulas()
    {
        XL.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveSheet;
        XL.Worksheet formulasWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["formulas"];
        XL.Range range = worksheet.UsedRange;
        arrValue = (object[,])range.get_Value(XL.XlRangeValueDataType.xlRangeValueDefault);
        for (int iRow = 1; iRow <= arrValue.GetLength(0); iRow++)
        {
            for (int iCol = 1; iCol <= arrValue.GetLength(1); iCol++)
            {
                 if (range.Cells[iRow, iCol].Formula != null)
                 {
                      range.Cells[iRow, iCol].Formula = "=" + kvp.Value.ToString();  // assign underlying formula (kvp is keyValuePair of dictionary) to the cell
                      formulasWorksheet.Cells[iRow, iCol].Value = kvp.Value.ToString(); // storing the formula here
                 }
                 range.Cells[iRow, iCol].Value = evalResults[count].ToString(); // assign value to the cell 
                 count++;
            }
        }
    }
    public void Recalculate()
    {
        XL.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveSheet;
        XL.Worksheet formulasWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["formulas"];
        XL.Range range = worksheet.UsedRange;
        arrValue = (object[,])range.get_Value(XL.XlRangeValueDataType.xlRangeValueDefault);
        for (int iRow = 1; iRow <= arrValue.GetLength(0); iRow++)
        {
            for (int iCol = 1; iCol <= arrValue.GetLength(1); iCol++)
            {
                 if (!string.IsNullOrEmpty(formulasWorksheet.Cells[iRow, iCol].Text))
                 {
                      range.Cells[iRow, iCol].Formula = "=" + formulasWorksheet.Cells[iRow, iCol].Text; // restoring the formula
                      range.Cells[iRow, iCol].Value = range.Cells[iRow, iCol].Value // replacing the formula with the value
                 }
            }
        }
    }
