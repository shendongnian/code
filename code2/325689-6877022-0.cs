    Excel.Range sourceRange = firstWorksheet.get_Range("A1", "J10");
    Excel.Range destinationRange = secondWorksheet.get_Range("A15", "J25");
    
    sourceRange.Copy(Type.Missing);
    destinationRange.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormulas, Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
