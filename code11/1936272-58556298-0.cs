    newWorksheet.Range["A1"].PasteSpecial(XlPasteType.xlPasteValues,
      XlPasteSpecialOperation.xlPasteSpecialOperationNone,
      System.Type.Missing,
      System.Type.Missing);
    newWorksheet.Cells.NumberFormat = "@"; 
