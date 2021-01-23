    private static void ReplaceFormulasWithValues(ref Excel.Worksheet sheet, char column)
    {
      Excel.Range range = (Excel.Range)sheet.get_Range(column + "1", Missing.Value).EntireColumn;
      range.Copy(Missing.Value);
      range.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteValues,
        Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
    }
